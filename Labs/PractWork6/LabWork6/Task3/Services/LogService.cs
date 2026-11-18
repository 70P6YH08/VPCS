using System.IO;
using System.Text;

namespace Task3.Serivces
{
    public class LogService
    {
        private static readonly string logPath = "exceptions.log";
        public async Task LogExceptionAsync(string exception)
        {
            try
            {
                using (StreamWriter streamWriter = new(logPath, true, Encoding.UTF8, 8192))
                {
                    await streamWriter.WriteLineAsync($"ОШИБКА: {exception}\n\t[{DateTime.UtcNow.Date:hh:mm:ss dd/MM/yyyy}]\n\n");
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Файл {logPath} не найден: " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
