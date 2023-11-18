using OfficeOpenXml;
using System.Text.Json;
using System.Text.RegularExpressions;
using TC_WinForms.Models;

namespace TC_WinForms.DataProcessing
{
    internal static class ExParserTC
    {

        internal delegate void MessageHandler(string message);
        
        static MessageHandler? msg;
        internal static void RegisterMessageHandler (MessageHandler? messegeOutMethod)
        {
            msg = messegeOutMethod;
        }

        internal static void RegisterFilePath(string filepath)
        {
            ExParserTC.filepath = filepath;
        }
        internal static void RegisterJsonCatalog(string jsonCatalog)
        {
            ExParserTC.jsonCatalog = jsonCatalog;
        }

        static List<string> listCardName = new();
        internal static void RegisterCardNameToParse(List<string> listCardName)
        {
            ExParserTC.listCardName = listCardName;
        }

        // Путь к файлу с ТК
        static string filepath;
        static string jsonCatalog;

        //Список ключевых слов (заголовков)
        static string[] keyWords =
        {
                "1. Требования к составу бригады и квалификации",
                "2. Требования к материалам и комплектующим",
                "3. Требования к механизмам",
                "4. Требования к средствам защиты",
                "5. Требования к инструментам и приспособлениям",
                "6. Выполнение работ"

            };
        static string[] stuctNames = { "Staff", "Components", "Machines", "Protection", "Tools", "WorkSteps" };



        public static void DoMain()
        {
            msg?.Invoke("Выполняется функционал консольного парсинга");

            // Ввод лицензии для работы с Excel
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            try
            {
                // Создаю объект для работы с Excel
                using (var package = new ExcelPackage(new FileInfo(filepath)))
                {
                    foreach (string sheetName in listCardName)
                    {
                        // Определение листа в переменную
                        var worksheet = package.Workbook.Worksheets[sheetName];

                        // Поиск номеров строк с ключевыми словами
                        int[] startRows = new int[keyWords.Count()+1];
                        startRows = StartRowsCounter(startRows, worksheet);

                        for (int i = 0; i < stuctNames.Count(); i++)
                        {
                            
                            try
                            {
                                // Запись данных из Excel в json в соответствии с моделью данных
                                switch (i)
                                {
                                    case 1:
                                        SaveToJSON(CreateListModel(new List<Struct>(), i, startRows, worksheet), i, sheetName);
                                        break;
                                    case 2:
                                        SaveToJSON(CreateListModel(new List<Struct>(), i, startRows, worksheet), i, sheetName);
                                        break;
                                    case 3:
                                        SaveToJSON(CreateListModel(new List<Struct>(), i, startRows, worksheet), i, sheetName);
                                        break;
                                    case 4:
                                        SaveToJSON(CreateListModel(new List<Struct>(), i, startRows, worksheet), i, sheetName);
                                        break;
                                    case 0:
                                        SaveToJSON(CreateListModel(new List<Staff>(), i, startRows, worksheet), i, sheetName);
                                        break;
                                    case 5:
                                        SaveToJSON(CreateListModel(new List<WorkStep>(), i, startRows, worksheet), i, sheetName);
                                        break;

                                    default:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                msg?.Invoke($"Ошибка при парсинге таблицы {keyWords[i]}:\n{ex.Message}");
                            }

                        }

                        msg?.Invoke($"Парсиг карты на листе {sheetName} законцен!");
                    }
                }
            }
            catch (Exception ex)
            {
                msg?.Invoke($"Произошла ошибка: {ex.Message}");
            }
            Console.ReadLine();

        }

        public static int[] StartRowsCounter(int[] startRows, ExcelWorksheet worksheet)
        {
            int numRowsFound = 0;
            int numLastRowStart = 0;
            bool lastTableStarts = false;
            for (int i = 1; i < 1000; i++)
            {
                string valueCell = worksheet.Cells[i, 1].Value != null ? worksheet.Cells[i, 1].Value.ToString() : "";
                string keyWord = keyWords[numRowsFound];
                switch (keyWord)
                {
                    case "6. Выполнение работ":

                        //TODO: Проверить бывают ли пункты не int пункты

                        if (valueCell.Contains(keyWord))
                        {
                            lastTableStarts = true;
                            numLastRowStart = i;
                            startRows[numRowsFound] = i;
                        }
                        else if (lastTableStarts && i != (numLastRowStart + 1) && !int.TryParse(valueCell, out int result))
                        {
                            startRows[numRowsFound] = numLastRowStart;
                            numRowsFound++;
                            startRows[numRowsFound] = i;
                            numRowsFound++;
                        }
                        break;
                    default:
                        if (valueCell.Contains(keyWord)) { startRows[numRowsFound] = i; numRowsFound++; }
                        break;
                }
                if (numRowsFound == startRows.Count()) { break; }
            }
            return startRows;
        }

        public enum StructType
        {
            Component = 2,
            Machine = 3,
            Protection = 4,
            Tool = 5
        }

        public static void SaveToJSON(List<Struct> ListOfStruct, int numTitle, string sheetName)
        {
            if (ListOfStruct.Count != 0)
            {
                foreach (var item in ListOfStruct)
                {
                    // Создание объекта для записи без кодировки в Unicode
                    var options = new JsonSerializerOptions
                    {
                        // set the encoder to UnicodeEncoding
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };

                    string json = JsonSerializer.Serialize(item, options);
                    string pathJson = $@"{jsonCatalog}\{sheetName}\{stuctNames[numTitle]}\";
                    if (!Directory.Exists(pathJson)) Directory.CreateDirectory(pathJson);
                    File.WriteAllText(pathJson + item.Num + ".json", json);
                }
            }
        }
        public static void SaveToJSON(List<Staff> ListOfStruct, int numTitle, string sheetName)
        {
            if (ListOfStruct.Count != 0)
            {
                foreach (var item in ListOfStruct)
                {
                    // Создание объекта для записи без кодировки в Unicode
                    var options = new JsonSerializerOptions
                    {
                        // set the encoder to UnicodeEncoding
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };

                    string json = JsonSerializer.Serialize(item, options);
                    string pathJson = $@"{jsonCatalog}\{sheetName}\{stuctNames[numTitle]}\";
                    if (!Directory.Exists(pathJson)) Directory.CreateDirectory(pathJson);
                    File.WriteAllText(pathJson + item.Num + ".json", json);
                }
            }
        }
        public static void SaveToJSON(List<WorkStep> ListOfStruct, int numTitle, string sheetName)
        {
            if (ListOfStruct.Count != 0)
            {
                foreach (var item in ListOfStruct)
                {
                    // Создание объекта для записи без кодировки в Unicode
                    var options = new JsonSerializerOptions
                    {
                        // set the encoder to UnicodeEncoding
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };

                    string json = JsonSerializer.Serialize(item, options);
                    string pathJson = $@"{jsonCatalog}\{sheetName}\{stuctNames[numTitle]}\";
                    if (!Directory.Exists(pathJson)) Directory.CreateDirectory(pathJson);
                    File.WriteAllText(pathJson + item.Num + ".json", json);
                }
            }
        }


        public static List<Struct> CreateListModel(List<Struct> structs, int numTitle, int[] startRows, ExcelWorksheet worksheet)
        {
            StructType structType = (StructType)Enum.ToObject(typeof(StructType), numTitle + 1);

            // Запись данных из Excel в список в соответствии с моделью данных
            int startRow = startRows[numTitle] + 2;
            int endRow = startRows[numTitle + 1];

            int itemCounter = 0;
            int itemWhithConponents = 0;
            // TODO: при работе с таблицей 2 комплектующие могу разбиварить на комплекты

            for (int i = startRow; i < endRow; i++)
            {

                // Поиск номеров столбцов с ключевыми словами
                int numCol = 1;
                int titleCol = FindColumn("Наименование", startRows[numTitle] + 1, worksheet);
                int typeCol = FindColumn("Тип (исполнение)", startRows[numTitle] + 1, worksheet);
                int initCol = FindColumn("Ед. Изм.", startRows[numTitle] + 1, worksheet);
                int amountCol = FindColumn("Кол-во", startRows[numTitle] + 1, worksheet);
                int priceCol = FindColumn("Стоимость, руб. без НДС", startRows[numTitle] + 1, worksheet);

                string num = worksheet.Cells[i, numCol].Value.ToString().Trim();
                string name = worksheet.Cells[i, titleCol].Value.ToString().Trim();
                //string? type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                string? type = null;
                if (worksheet.Cells[i, typeCol].Value != null)
                {
                    type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                }
                string unit = worksheet.Cells[i, initCol].Value.ToString().Trim();
                string? amount = amountCol != 0 ? worksheet.Cells[i, amountCol].Value.ToString().Trim() : "0";
                //string? price = priceCol != 0 ? worksheet.Cells[i, priceCol].Value.ToString().Trim() : null;
                string? price = null;
                if (priceCol != 0 && worksheet.Cells[i, typeCol].Value != null)
                {
                    type = worksheet.Cells[i, typeCol].Value.ToString().Trim();
                }

                if (structType == StructType.Tool)
                {
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
                else if (structType == StructType.Component)
                {
                    
                    if (name.Contains("в составе")) itemWhithConponents = itemCounter;

                    if (itemCounter > itemWhithConponents && num == "-") 
                    {
                        structs[itemWhithConponents].AddComplectItem(new Component
                        {
                            Num = 0,
                            Name = name,
                            Type = type,
                            Unit = unit,
                            Amount = double.Parse(amount),
                            Price = price != null ? float.Parse(price) : null
                        });
                    }
                    else { 
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
                else if (structType == StructType.Protection)
                {
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
                else if (structType == StructType.Machine)
                {
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
            }
            
            return structs;
        }
        public static List<Staff> CreateListModel(List<Staff> structs, int numTitle, int[] startRows, ExcelWorksheet worksheet)
        {
            int startRow = startRows[numTitle] + 2;
            int endRow = startRows[numTitle + 1];

            // Поиск номеров столбцов с ключевыми словами
            int numCol = 1;
            int titleCol = FindColumn("Наименование", startRows[numTitle] + 1, worksheet);
            int typeCol = FindColumn("Тип (исполнение)", startRows[numTitle] + 1, worksheet);
            int combineResponsibilityCol = FindColumn("Возможность совмещения обязанностей", startRows[numTitle] + 1, worksheet);
            int elSaftyGroupCol = FindColumn("Группа ЭБ, не ниже", startRows[numTitle] + 1, worksheet);
            int gradeCol = FindColumn("Разряд,\r\nне ниже", startRows[numTitle] + 1, worksheet);
            int competenceCol = FindColumn("Квалификация", startRows[numTitle] + 1, worksheet);
            int symbolCol = FindColumn("Обозначение в ТК", startRows[numTitle] + 1, worksheet);

            for (int i = startRow; i < endRow; i++)
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
        public static List<WorkStep> CreateListModel(List<WorkStep> structs, int numTitle, int[] startRows, ExcelWorksheet worksheet)
        {
            // Определение начальной и конечной строки для парсинга
            int startRow = startRows[numTitle] + 2;
            int endRow = startRows[numTitle + 1];

            // Поиск номеров столбцов с ключевыми словами
            int numCol = 1; //FindColumn("№", startRows[numTitle] + 1, worksheet);
            int descriptionCol = FindColumn(new string[] { "Описание работ", "Технологические переходы"}, startRows[numTitle] + 1, worksheet);
            int stepTimeCol = FindColumn("Время выполнения действия, мин.", startRows[numTitle] + 1, worksheet);
            int protectionCol = FindColumn("№ средства защиты", startRows[numTitle] + 1, worksheet);


            for (int i = startRow; i < endRow; i++)
            {
                string num = worksheet.Cells[i, numCol].Value.ToString().Trim();

                string allDescription = worksheet.Cells[i, descriptionCol].Value.ToString();

                string[] parts = allDescription.Split(':', 2);
                string? staff, description, comments;
                string[] parts2;
                if (parts.Count() == 2)
                {
                    staff = parts[0].Trim();
                    parts2 = parts[1].Split("Примечание:", 2);
                    description = Regex.Replace(parts2[0].Trim(), @"\s+", " ");
                    comments = parts2.Count() == 2 ? parts2[1].Trim() : null;
                }
                else
                {
                    staff = null;
                    parts2 = parts[0].Split("Примечание:", 2);
                    description = Regex.Replace(parts2[0].Trim(), @"\s+", " ");
                    comments = parts2.Count() == 2 ? parts2[1].Trim() : null;
                }

                string stepExecutionTime = "0";
                if (worksheet.Cells[i, stepTimeCol].Value != null)
                {
                    stepExecutionTime = worksheet.Cells[i, stepTimeCol].Value.ToString().Trim();
                    WorkStep.AddStage(WorkStep.GetLastStageNum() + 1, float.Parse(worksheet.Cells[i, 6].Value.ToString().Trim()));
                }

                string stageExecutionTime = WorkStep.GetLastStageTime().ToString();
                string stage = WorkStep.GetLastStageNum().ToString();
                //string machineExecutionTime = worksheet.Cells[i, 7].Value.ToString().Trim();
                string? protections = null;
                if (worksheet.Cells[i, protectionCol].Value != null)
                {
                    protections = worksheet.Cells[i, protectionCol].Value.ToString().Trim();
                }
                structs.Add(new WorkStep
                {
                    Num = int.Parse(num),
                    Description = description,
                    Staff = staff,
                    StepExecutionTime = float.Parse(stepExecutionTime),
                    StageExecutionTime = float.Parse(stageExecutionTime),
                    Stage = int.Parse(stage),
                    Protections = protections,
                    Comments = comments
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
