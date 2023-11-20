using OfficeOpenXml;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using TC_WinForms.Models;

namespace TC_WinForms.DataProcessing
{
    internal class FromExelToObjectMapper
    {

        // create dictionarys with start and end rows for EModelType from keyValuePairs
        Dictionary<EModelType?, int> modelStartRows = new();
        Dictionary<EModelType?, int> modelEndRows = new();
        Dictionary<EModelType, List<IModelStructure>> modelsList = new();

        public Dictionary<EModelType, List<IModelStructure>> GetModelsList() { return modelsList; }

        public void mapFrom(Dictionary<string, EModelType> keyValuePairs, ExcelWorksheet worksheet) 
        {
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
                        modelsList[eModel] = ParseComponetns(startRow, endRow, worksheet);
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

        }

        public void FindTableBorderRows(Dictionary<string, EModelType> keyValuePairs, ExcelWorksheet worksheet,
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

            for (int i = 1; i < 1000; i++)
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

        public static List<IModelStructure> ParseStaffs(int startRow, int endRow, ExcelWorksheet worksheet)
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
        private List<IModelStructure> ParseComponetns(int startRow, int endRow, ExcelWorksheet worksheet)
        {
            List<IModelStructure> structs = new ();

            // We suppose that the row with the headers is under the startRow
            int columnRow = startRow + 1;

            int itemCounter = 0;
            int itemWhithConponents = 0;

            // TODO: при работе с таблицей 2 комплектующие могут разбивариться на комплекты

            for (int i = startRow + 2; i < endRow; i++)
            {
                int numCol = 1;
                int titleCol = FindColumn("Наименование", columnRow, worksheet);
                int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
                int initCol = FindColumn("Ед. Изм.", columnRow, worksheet);
                int amountCol = FindColumn("Кол-во", columnRow, worksheet);
                int priceCol = FindColumn("Стоимость, руб. без НДС", columnRow, worksheet);

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

                if (name.Contains("в составе")) itemWhithConponents = itemCounter;

                    if (itemCounter > itemWhithConponents && num == "-")
                    {
                        ((Component)structs[itemWhithConponents]).AddComplectItem(new Component
                        {
                            Num = 0,
                            Name = name,
                            Type = type,
                            Unit = unit,
                            Amount = double.Parse(amount),
                            Price = price != null ? float.Parse(price) : null
                        });
                    }
                    else
                    {
                        if (itemWhithConponents != 0 && itemCounter > itemWhithConponents) itemWhithConponents = 0; // Сброс счетчика (исключаем попадание компонентов из другого списка)
                        structs.Add(new Component
                        {
                            Num = int.Parse(num),
                            Name = name,
                            Type = type,
                            Unit = unit,
                            Amount = double.Parse(amount),
                            Price = price != null ? float.Parse(price) : null
                        });

                    }

                    itemCounter++;
                
            }

            return structs;
        }
        public static List<IModelStructure> ParseMachines(int startRow, int endRow, ExcelWorksheet worksheet)
        {
            List < IModelStructure > structs = new();
            int columnRow = startRow + 1;

            for (int i = startRow + 2; i < endRow; i++)
            {
                int numCol = 1;
                int titleCol = FindColumn("Наименование", columnRow, worksheet);
                int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
                int initCol = FindColumn("Ед. Изм.", columnRow, worksheet);
                int amountCol = FindColumn("Кол-во", columnRow, worksheet);
                int priceCol = FindColumn("Стоимость, руб. без НДС", columnRow, worksheet);

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
        public static List<IModelStructure> ParseProtections(int startRow, int endRow, ExcelWorksheet worksheet)    
        {
            List<IModelStructure> structs = new();
            int columnRow = startRow + 1;
            for (int i = startRow + 2; i < endRow; i++)
            {
                int numCol = 1;
                int titleCol = FindColumn("Наименование", columnRow, worksheet);
                int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
                int initCol = FindColumn("Ед. Изм.", columnRow, worksheet);
                int amountCol = FindColumn("Кол-во", columnRow, worksheet);
                int priceCol = FindColumn("Стоимость, руб. без НДС", columnRow, worksheet);

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
        public static List<IModelStructure> ParseTools(int startRow, int endRow, ExcelWorksheet worksheet)
        {
            List<IModelStructure> structs = new();
            int columnRow = startRow + 1;

            for (int i = startRow + 2; i < endRow; i++)
            {
                int numCol = 1;
                int titleCol = FindColumn("Наименование", columnRow, worksheet);
                int typeCol = FindColumn("Тип (исполнение)", columnRow, worksheet);
                int initCol = FindColumn("Ед. Изм.", columnRow, worksheet);
                int amountCol = FindColumn("Кол-во", columnRow, worksheet);
                int priceCol = FindColumn("Стоимость, руб. без НДС", columnRow, worksheet);

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


        public static int FindColumn(string columnName, int columnRow, ExcelWorksheet worksheet)
        {
            string[] columnNameList = { columnName };
            return FindColumn(columnNameList, columnRow, worksheet);
        }

        public static int FindColumn(string[] columnNameList, int columnRow, ExcelWorksheet worksheet)
        {
            int numColumn = 0;
            for (int i = 1; i < 100; i++)
            {
                if (worksheet.Cells[columnRow, i].Value != null && columnNameList.Contains(worksheet.Cells[columnRow, i].Value.ToString()))
                { numColumn = i; break; }
            }
            return numColumn;
        }
    }
}
