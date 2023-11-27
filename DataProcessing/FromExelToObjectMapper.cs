using OfficeOpenXml;
using TC_WinForms.Models;
using ExcelParsing.DataProcessing;

namespace TC_WinForms.DataProcessing
{
    public class FromExelToObjectMapper
    {
        const int maxRow = 1000;
        const int maxColumn = 20;

        // create dictionarys with start and end rows for EModelType from keyValuePairs
        private Dictionary<EModelType?, int> modelStartRows = new();
        private Dictionary<EModelType?, int> modelEndRows = new();

        public Dictionary<EModelType, List<IModelStructure>> mapFrom(Dictionary<string, EModelType> keyValuePairs, ExcelWorksheet worksheet) 
        {
            Dictionary<EModelType, List<IModelStructure>> modelsList = new();

            EModelType[] eModels = new EModelType[keyValuePairs.Count];
            keyValuePairs.Values.CopyTo(eModels, 0);

            FindTableBorderRows(keyValuePairs, worksheet,out modelStartRows,out modelEndRows);
            foreach (EModelType eModel in eModels)
            {
                int startRow = modelStartRows[eModel];
                int endRow = modelEndRows[eModel];
                switch (eModel)
                {
                    case EModelType.Staff:
                        modelsList[eModel] = ParseStaffs(startRow, endRow, worksheet);
                        break;
                    case EModelType.Component:
                        //modelsList[eModel] = ParseComponetns(startRow, endRow, worksheet);
                        break;
                    case EModelType.Machine:
                        modelsList[eModel] = ParseMachines(startRow, endRow, worksheet);
                        break;
                    case EModelType.Protection:
                        modelsList[eModel] = ParseProtections(startRow, endRow, worksheet);
                        break;
                    case EModelType.Tool:
                        modelsList[eModel] = ParseTools(startRow, endRow, worksheet);
                        break;
                    //case EModelType.WorkStep:
                    //    modelsList[eModel] = ParseStaffs(startRow, endRow, worksheet);
                    //    break;
                    default:
                        break;
                }
            }
            return modelsList;
        }

        private void FindTableBorderRows(Dictionary<string, EModelType> keyValuePairs, ExcelWorksheet worksheet,
            out Dictionary<EModelType?, int> modelStartRows,
            out Dictionary<EModelType?, int> modelEndRows)
        {

            modelStartRows= new();
            modelEndRows = new();
            foreach (var item in keyValuePairs)
            {
                modelStartRows.Add(item.Value, 0);
                modelEndRows.Add(item.Value, 0);
            }

            EModelType? currentTableType = null;

            bool lastTableStarts = false;

            for (int i = 1; i < maxRow; i++)
            {
                string valueCell = worksheet.Cells[i, 1].Value != null ? worksheet.Cells[i, 1].Value.ToString() : "";

                if (keyValuePairs.Keys.Contains(valueCell))
                {
                    foreach (var item in keyValuePairs)
                    {
                        if (item.Key == valueCell)
                        {
                            if (currentTableType != null) modelEndRows[currentTableType] = i - 1;
                            currentTableType = item.Value;
                            modelStartRows[item.Value] = i;

                            // check if it is last table (as if it no one 0 value in modelStartRows)
                            if (!modelStartRows.Values.Contains(0)) { lastTableStarts = true; }
                            break;
                        }
                    }
                }
                // looking for last row of last table as first row whith null or unparsable it double value in "A" column
                if (lastTableStarts && i > modelStartRows[currentTableType] + 1)
                {
                    if (valueCell == "" || !double.TryParse(valueCell, out double _))
                    {
                        modelEndRows[currentTableType] = i - 1;
                        break;
                    }

                }
            }
        }

        private List<IModelStructure> ParseStaffs(int startRow, int endRow, ExcelWorksheet worksheet)
        {
            List<IModelStructure> structs = new();
            int columnRow = startRow + 1;

            // Поиск номеров столбцов с ключевыми словами
            int numCol = 1;
            int titleCol = FindColumn("Наименование", columnRow, worksheet);
            int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
            int combineResponsibilityCol = FindColumn("Возможность совмещения обязанностей", columnRow, worksheet);
            int elSaftyGroupCol = FindColumn("Группа ЭБ, не ниже", columnRow, worksheet);
            int gradeCol = FindColumn("Разряд,\r\nне ниже", columnRow, worksheet);
            int competenceCol = FindColumn("Квалификация", columnRow, worksheet);
            int symbolCol = FindColumn("Обозначение в ТК", columnRow, worksheet);

            for (int i = startRow + 2; i < endRow; i++)
            {
                structs.Add(new Staff
                {
                    Num = int.Parse(worksheet.Cells[i, numCol].Value.ToString().Trim()),
                    Name = worksheet.Cells[i, titleCol].Value.ToString().Trim(),
                    Type = worksheet.Cells[i, typeCol].Value.ToString().Trim(),
                    CombineResponsibility = worksheet.Cells[i, combineResponsibilityCol].Value.ToString().Trim(),
                    ElSaftyGroup = elSaftyGroupCol != 0 ? worksheet.Cells[i, elSaftyGroupCol].Value.ToString().Trim() : null,
                    Grade = gradeCol != 0 ? worksheet.Cells[i, 6].Value.ToString().Trim() : null,
                    Competence = worksheet.Cells[i, competenceCol].Value.ToString().Trim(),
                    Symbol = worksheet.Cells[i, symbolCol].Value.ToString().Trim(),

                });
            }
            return structs;
        }
        public List<IModelStructure> ParseComponetns(string filepath, string sheetName, int startRow, int endRow)
        {
            var structs = new List<IModelStructure>();
            List<string> columnsNames = new List<string> 
            { "№", "Наименование", "Тип (исполнение)", "Ед. Изм.", "Кол-во", "Стоимость, руб. без НДС" };

            var parser = new ExcelParser();
            var parsedData = parser.ParseRowsToStrings(columnsNames,filepath,sheetName,startRow,endRow);

            // We suppose that the row with the headers is under the startRow
            int columnRow = startRow + 1;

            int itemCounter = 0;
            int itemWhithConponents = 0;

            // TODO: при работе с таблицей 2 комплектующие могут разбивариться на комплекты
            // todo - create a method for finding column by name in a loop
            
            foreach (var row in parsedData)
            {
                string num = row[columnsNames.IndexOf("№")];
                string name = row[columnsNames.IndexOf("Наименование")];

                string? type = row[columnsNames.IndexOf("Наименование")];
                //if (worksheet.Cells[i, columnsNums[2]].Value != null)
                //{
                //    type = worksheet.Cells[i, columnsNums[2]].Value.ToString().Trim();
                //}
                string unit = row[columnsNames.IndexOf("Наименование")];
                string? amount = row[columnsNames.IndexOf("Наименование")];

                string? price = row[columnsNames.IndexOf("Наименование")];
                //if (columnsNums[5] != 0 && worksheet.Cells[i, columnsNums[5]].Value != null)
                //{
                //    type = worksheet.Cells[i, columnsNums[5]].Value.ToString().Trim();
                //}

                structs.Add(new Component
                {
                    Num = int.Parse(num),
                    Name = name,
                    Type = type,
                    Unit = unit,
                    Amount = double.Parse(amount),
                    Price = price != null ? float.Parse(price) : null
                });

                //if (name.Contains("в составе")) itemWhithConponents = itemCounter;

                //if (itemCounter > itemWhithConponents && num == "-")
                //{
                //    ((Component)structs[itemWhithConponents]).AddComplectItem(new Component
                //    {
                //        Num = 0,
                //        Name = name,
                //        Type = type,
                //        Unit = unit,
                //        Amount = double.Parse(amount),
                //        Price = price != null ? float.Parse(price) : null
                //    });
                //}
                //else
                //{
                //    if (itemWhithConponents != 0 && itemCounter > itemWhithConponents) itemWhithConponents = 0; // Сброс счетчика (исключаем попадание компонентов из другого списка)

                //    structs.Add(new Component
                //    {
                //        Num = int.Parse(num),
                //        Name = name,
                //        Type = type,
                //        Unit = unit,
                //        Amount = double.Parse(amount),
                //        Price = price != null ? float.Parse(price) : null
                //    });

                //}

                //itemCounter++;
            }

            return structs;
        }
        private List<IModelStructure> ParseMachines(int startRow, int endRow, ExcelWorksheet worksheet)
        {
            List<IModelStructure> structs = new();
            int columnRow = startRow + 1;

            int numCol = 1;
            int titleCol = FindColumn("Наименование", columnRow, worksheet);
            int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
            int initCol = FindColumn("Ед. Изм.", columnRow, worksheet);
            int amountCol = FindColumn("Кол-во", columnRow, worksheet);
            int priceCol = FindColumn("Стоимость, руб. без НДС", columnRow, worksheet);

            for (int i = startRow + 2; i < endRow; i++)
            {
                string num = worksheet.Cells[i, numCol].Value.ToString().Trim();
                string name = worksheet.Cells[i, titleCol].Value.ToString().Trim();
                string? type = null;
                if (worksheet.Cells[i, typeCol].Value != null)
                {
                    type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                }
                string unit = worksheet.Cells[i, initCol].Value.ToString().Trim();
                string? amount = amountCol != 0 ? worksheet.Cells[i, amountCol].Value.ToString().Trim() : "0";
                string? price = null;
                if (priceCol != 0 && worksheet.Cells[i, typeCol].Value != null)
                {
                    type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                }

                structs.Add(new Machine
                {
                    Num = int.Parse(num),
                    Name = name,
                    Type = type,
                    Unit = unit,
                    Amount = double.Parse(amount),
                    Price = price != null ? float.Parse(price) : null
                });
            }

            return structs;
        }
        private List<IModelStructure> ParseProtections(int startRow, int endRow, ExcelWorksheet worksheet)    
        {
            List<IModelStructure> structs = new();
            int columnRow = startRow + 1;
            int numCol = 1;
            int titleCol = FindColumn("Наименование", columnRow, worksheet);
            int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
            int initCol = FindColumn("Ед. Изм.", columnRow, worksheet);
            int amountCol = FindColumn("Кол-во", columnRow, worksheet);
            int priceCol = FindColumn("Стоимость, руб. без НДС", columnRow, worksheet);

            for (int i = startRow + 2; i < endRow; i++)
            {
                string num = worksheet.Cells[i, numCol].Value.ToString().Trim();
                string name = worksheet.Cells[i, titleCol].Value.ToString().Trim();
                string? type = null;
                if (worksheet.Cells[i, typeCol].Value != null)
                {
                    type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                }
                string unit = worksheet.Cells[i, initCol].Value.ToString().Trim();
                string? amount = amountCol != 0 ? worksheet.Cells[i, amountCol].Value.ToString().Trim() : "0";
                string? price = null;
                if (priceCol != 0 && worksheet.Cells[i, typeCol].Value != null)
                {
                    type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                }

                structs.Add(new Protection
                {
                    Num = int.Parse(num),
                    Name = name,
                    Type = type,
                    Unit = unit,
                    Amount = double.Parse(amount),
                    Price = price != null ? float.Parse(price) : null
                });
            }

            return structs;
        }
        private List<IModelStructure> ParseTools(int startRow, int endRow, ExcelWorksheet worksheet)
        {
            List<IModelStructure> structs = new();
            int columnRow = startRow + 1;
            int numCol = 1;
            int titleCol = FindColumn("Наименование", columnRow, worksheet);
            int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
            int initCol = FindColumn("Ед. Изм.", columnRow, worksheet);
            int amountCol = FindColumn("Кол-во", columnRow, worksheet);
            int priceCol = FindColumn("Стоимость, руб. без НДС", columnRow, worksheet);

            for (int i = startRow + 2; i < endRow; i++)
            {
                
                string num = GetCellValue(i, numCol, worksheet);
                string name = GetCellValue(i, titleCol, worksheet); 
                string? type = GetCellValue(i, typeCol, worksheet, null);
                string unit = worksheet.Cells[i, initCol].Value.ToString().Trim();
                string? amount = amountCol != 0 ? worksheet.Cells[i, amountCol].Value.ToString().Trim() : "0";
                string? price = null;
                if (priceCol != 0 && worksheet.Cells[i, typeCol].Value != null)
                {
                    type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                }
                structs.Add(new Tool
                {
                    Num = int.Parse(num),
                    Name = name,
                    Type = type,
                    Unit = unit,
                    Amount = double.Parse(amount),
                    Price = price != null ? float.Parse(price) : null
                });
                
                
            }

            return structs;
        }

        private int[] FindListColumn(string[] columnNameList, int columnRow, ExcelWorksheet worksheet)
        {
            int[] numColumn = new int[columnNameList.Length];
            for (int i = 0; i < columnNameList.Length; i++)
            {
                numColumn[i] = FindColumn(columnNameList[i], columnRow, worksheet);
            }
            return numColumn;
        }
        private int FindColumn(string columnName, int columnRow, ExcelWorksheet worksheet) 
        {
            string[] columnNameList = { columnName };
            return FindColumn(columnNameList, columnRow, worksheet);
        }
        private int FindColumn(string[] columnNameList, int columnRow, ExcelWorksheet worksheet)
        {
            int numColumn = 0;
            for (int i = 1; i < maxColumn; i++)
            {
                if (worksheet.Cells[columnRow, i].Value != null && columnNameList.Contains(worksheet.Cells[columnRow, i].Value.ToString()))
                { numColumn = i; break; }
            }
            return numColumn;
        }
        private string GetCellValue(int row, int column, ExcelWorksheet worksheet)
        {
            return worksheet.Cells[row, column].Value?.ToString()?.Trim();
        }
        private string? GetCellValue(int row, int column, ExcelWorksheet worksheet, string? defaultValue)
        {
            return GetCellValue(row, column, worksheet) ?? defaultValue; // 
        }

        private List<string> GetCellsValue(ExcelWorksheet worksheet, int[] columns, int row) //int row, int column, ExcelWorksheet worksheet)
        {
            columns[columns.Length - 1] = 172;
            List<string> values = new List<string>();
            foreach (var column in columns)
            {
                values.Add(GetCellValue(row, column, worksheet));
            }
            return values;
        }
    }
}
