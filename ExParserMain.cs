using OfficeOpenXml;

using TC_WinForms.DataProcessing;

namespace TC_WinForms
{
    public partial class ExParserMain : Form
    {
        // Путь к файлу с ТК
        static string filepath = @"C:\Users\bokar\Documents\ТК.xlsx";
        static string jsonCatalog = @"Temp\Cards";

        List<String> sheetsTK = new();
        public ExParserMain()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            InitializeComponent();
            // Задание начальных значений для элементов формы
            txtFilePath.Text = filepath;
        }

        private void btnFilePathCheck_Click(object sender, EventArgs e)
        {

            string filePathCheck = txtFilePath.Text;
            if (File.Exists(filePathCheck))
            {


                // Получение названия всех листов с ТК в книге
                // Передача названий листов в clbxTCSheets
                using (var package = new ExcelPackage(new FileInfo(filepath)))
                {
                    foreach (var ws in package.Workbook.Worksheets)
                    {
                        if (ws.Name.ToString().Contains("ТК_")) sheetsTK.Add(ws.Name);
                    }

                }

                btnFilePathCheck.Visible = false;
                gbxTCSheets.Visible = true;

                sheetsTK.Sort();
                clbxTCSheets.DataSource = sheetsTK;
                filepath = filePathCheck;

            }
            else MessageBox.Show("Файл по указаному пути не найден!");
        }

        private void btnTCSheetsSelectAll_Click(object sender, EventArgs e)
        {
            if (btnTCSheetsSelectAll.Text == "Выделить всё")
            {
                for (int i = 0; i < clbxTCSheets.Items.Count; i++)
                {
                    clbxTCSheets.SetItemChecked(i, true);
                }
                btnTCSheetsSelectAll.Text = "Отменить\nвыделение";
            }
            else
            {
                for (int i = 0; i < clbxTCSheets.Items.Count; i++)
                {
                    clbxTCSheets.SetItemChecked(i, false);
                }
                btnTCSheetsSelectAll.Text = "Выделить всё";
            }

        }

        private void btnParseFile_Click(object sender, EventArgs e)
        {
            // Проверить наличие в списке выбранных листов хотя бы одного
            if (clbxTCSheets.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не выбран ни один лист с ТК!");
                return;
            }

            // Выделяем список в отдельный список
            List<string> sheetsToParse = new();
            foreach (var item in clbxTCSheets.CheckedItems)
            {
                sheetsToParse.Add(item.ToString());
            }

            // Проверить наличие папки с каталогом
            if (!Directory.Exists(jsonCatalog))
            {
                try
                {
                    // Попытка создания тестовой директории
                    var testDir = Directory.CreateDirectory(jsonCatalog);
                    //Console.WriteLine($"Тестовая директория успешно создана: {testDir.FullName}");
                    jsonCatalog = testDir.FullName;
                    Directory.Delete(jsonCatalog); // Удаление тестовой директории

                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Нет разрешения на создание директории.");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    return;
                }
            }

            // Регистрирую делигат для вывода сообщений
            ExParser.RegisterMessageHandler(PrintMessage);
            ExParser.RegisterFilePath(filepath);
            ExParser.RegisterJsonCatalog(jsonCatalog);
            ExParser.RegisterCardNameToParse(sheetsToParse);

            ExParser.DoMain();
            Directory.CreateDirectory(jsonCatalog);
            MessageBox.Show("Hello World!");
        }

        void PrintMessage(string message) => MessageBox.Show(message);
    }


}
