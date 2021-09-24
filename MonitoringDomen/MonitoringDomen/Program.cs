using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringDomen
{
    public sealed class AppDomainMonitorDelta : IDisposable
    {
        private AppDomain m_appDomain;
        private TimeSpan m_thisADCpu;
        private Int64 m_thisADMemoryInUse;
        private Int64 m_thisADMemoryAllocated;
        static AppDomainMonitorDelta()
        {
            // Проверяем, что включен режим мониторинга домена
            AppDomain.MonitoringIsEnabled = true;
        }
        public AppDomainMonitorDelta(AppDomain ad)
        {
            m_appDomain = ad ?? AppDomain.CurrentDomain;
            m_thisADCpu = m_appDomain.MonitoringTotalProcessorTime;
            m_thisADMemoryInUse = m_appDomain.MonitoringSurvivedMemorySize;
            m_thisADMemoryAllocated = m_appDomain.MonitoringTotalAllocatedMemorySize;
        }
        public void Dispose()
        {
            GC.Collect();
            Console.WriteLine("FriendlyName={0}, CPU={1}ms",
            m_appDomain.FriendlyName,
            (m_appDomain.MonitoringTotalProcessorTime - m_thisADCpu).TotalMilliseconds);
            Console.WriteLine(
            " Allocated {0:N0} bytes of which {1:N0} survived GCs",
            m_appDomain.MonitoringTotalAllocatedMemorySize - m_thisADMemoryAllocated,
            m_appDomain.MonitoringSurvivedMemorySize - m_thisADMemoryInUse);
        }
        private static void AppDomainResourceMonitoring()
        {
            using (new AppDomainMonitorDelta(null))
            {
                // Выделение около 10 миллионов байтов,
                // которые переживут сборку мусора
                var list = new List<Object>();
                for (Int32 x = 0; x < 1000; x++) list.Add(new Byte[10000]);
                // Выделение около 20 миллионов байтов,
                // которые НЕ переживут уборку мусора
                for (Int32 x = 0; x < 2000; x++) new Byte[10000].GetType();
                // Прокрутка процессора около 5 секунд
                Int64 stop = Environment.TickCount + 5000;
                while (Environment.TickCount < stop) ;
            }
        }
    }
    class Program
        {
            static void Main(string[] args)
            {
            
            }
        }
    }
