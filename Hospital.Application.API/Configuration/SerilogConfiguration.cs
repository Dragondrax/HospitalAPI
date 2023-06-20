using Serilog;
using Serilog.Events;
using TelegramSink;

namespace Hospital.Application.API.Configuration
{
    public static class SerilogConfiguration
    {
        public static void AddSerilogApi()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.TeleSink(
                    telegramApiKey: "6005598521:AAHBZPipbWtd562WHoNuWL6AaBe_D0XmvVs",
                    telegramChatId: "-976598383",
                    minimumLevel: LogEventLevel.Error
                ).CreateLogger();
        }
    }
}
