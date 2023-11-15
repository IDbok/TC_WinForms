﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TC_WinForms.Models;

namespace TC_WinForms.DataProcessing
{
    internal static class ExParser
    {

        internal delegate void MessageHandler(string message);
        
        static MessageHandler? msg;
        internal static void RegisterMessageHandler (MessageHandler? messegeOutMethod)
        {
            msg = messegeOutMethod;
        }

        internal static void RegisterFilePath(string filepath)
        {
            ExParser.filepath = filepath;
        }
        internal static void RegisterJsonCatalog(string jsonCatalog)
        {
            ExParser.jsonCatalog = jsonCatalog;
        }

        static List<string> listCardName = new();
        internal static void RegisterCardNameToParse(List<string> listCardName)
        {
            ExParser.listCardName = listCardName;
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
                "6. Выполнение работ",
                ""

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

                        for (int i = 0; i < stuctNames.Count(); i++)
                        {
                            // Поиск номеров строк с ключевыми словами
                            int[] startRows = new int[keyWords.Count()];
                            startRows = StartRowsCounter(startRows, worksheet);
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
            for (int i = 1; i < 1000; i++)
            {

                string valueCell = worksheet.Cells[i, 1].Value != null ? worksheet.Cells[i, 1].Value.ToString() : "";
                string keyWord = keyWords[numRowsFound];
                if (valueCell == keyWord)
                {
                    startRows[numRowsFound] = i;
                    numRowsFound++;
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
        public static void SaveToJSON(List<Staff> ListOfStruct, int numTitle, string sheetName)
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
        public static void SaveToJSON(List<WorkStep> ListOfStruct, int numTitle, string sheetName)
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


        public static List<Struct> CreateListModel(List<Struct> structs, int numTitle, int[] startRows, ExcelWorksheet worksheet)
        {
            StructType structType = (StructType)Enum.ToObject(typeof(StructType), numTitle + 1);
            // Запись данных из Excel в список в соответствии с моделью данных
            int startRow = startRows[numTitle] + 2;
            int endRow = startRows[numTitle + 1];
            for (int i = startRow; i < endRow; i++)
            {
                string num = worksheet.Cells[i, 1].Value.ToString().Trim();
                string name = worksheet.Cells[i, 2].Value.ToString().Trim();
                string type = worksheet.Cells[i, 3].Value.ToString().Trim();
                string unit = worksheet.Cells[i, 4].Value.ToString().Trim();
                string amount = worksheet.Cells[i, 5].Value.ToString().Trim();

                if (structType == StructType.Tool)
                {
                    structs.Add(new Tool
                    {
                        Num = int.Parse(num),
                        Name = name,
                        Type = type,
                        Unit = unit,
                        Amount = (int)uint.Parse(amount)
                    });
                }
                else if (structType == StructType.Component)
                {
                    structs.Add(new Component
                    {
                        Num = int.Parse(num),
                        Name = name,
                        Type = type,
                        Unit = unit,
                        Amount = (int)uint.Parse(amount)
                    });
                }
                else if (structType == StructType.Protection)
                {
                    structs.Add(new Protection
                    {
                        Num = int.Parse(num),
                        Name = name,
                        Type = type,
                        Unit = unit,
                        Amount = (int)uint.Parse(amount)
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
                        Amount = (int)uint.Parse(amount)
                    });
                }
            }
            return structs;
        }
        public static List<Staff> CreateListModel(List<Staff> structs, int numTitle, int[] startRows, ExcelWorksheet worksheet)
        {
            int startRow = startRows[numTitle] + 2;
            int endRow = startRows[numTitle + 1];
            int symbolCol = FindColumn("Обозначение в ТК", startRows[numTitle] + 1, worksheet);
            for (int i = startRow; i < endRow; i++)
            {
                string num = worksheet.Cells[i, 1].Value.ToString().Trim();
                string name = worksheet.Cells[i, 2].Value.ToString().Trim();
                string type = worksheet.Cells[i, 3].Value.ToString().Trim();
                string combineResponsibility = worksheet.Cells[i, 4].Value.ToString().Trim();
                string elSaftyGroup = worksheet.Cells[i, 5].Value.ToString().Trim();
                string grade = worksheet.Cells[i, 6].Value.ToString().Trim();
                string competence = worksheet.Cells[i, 7].Value.ToString().Trim();
                string symbol = worksheet.Cells[i, symbolCol].Value.ToString().Trim();
                //string comment = worksheet.Cells[i, 12].Value.ToString().Trim();

                structs.Add(new Staff
                {
                    Num = int.Parse(num),
                    Name = name,
                    Type = type,
                    CombineResponsibility = combineResponsibility,
                    ElSaftyGroup = elSaftyGroup,
                    Grade = grade,
                    Competence = competence,
                    Symbol = symbol,
                    //Comment = comment
                });
            }
            return structs;
        }
        public static List<WorkStep> CreateListModel(List<WorkStep> structs, int numTitle, int[] startRows, ExcelWorksheet worksheet)
        {
            int startRow = startRows[numTitle] + 2;
            int endRow = startRows[numTitle + 1];
            int protectionCol = FindColumn("№ средства защиты", startRows[numTitle] + 1, worksheet);

            for (int i = startRow; i < endRow; i++)
            {
                string num = worksheet.Cells[i, 1].Value.ToString().Trim();

                string allDescription = worksheet.Cells[i, 2].Value.ToString();

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

                string stepExecutionTime = worksheet.Cells[i, 5].Value.ToString().Trim();
                if (worksheet.Cells[i, 6].Value != null)
                {
                    WorkStep.AddStage(WorkStep.GetLastStageNum() + 1, float.Parse(worksheet.Cells[i, 6].Value.ToString().Trim()));
                }
                string stageExecutionTime = WorkStep.GetLastStageTime().ToString();
                string stage = WorkStep.GetLastStageNum().ToString();
                //string machineExecutionTime = worksheet.Cells[i, 7].Value.ToString().Trim();
                string protections = worksheet.Cells[i, protectionCol].Value.ToString().Trim();


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
            int numColumn = 0;
            for (int i = 1; i < 100; i++)
            {
                if (worksheet.Cells[columnRow, i].Value != null && worksheet.Cells[columnRow, i].Value.ToString() == columnName)
                { numColumn = i; break; }
            }
            return numColumn;
        }

    }
}
