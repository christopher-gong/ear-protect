using CSCore.CoreAudioAPI;
using System;
using System.Threading;


namespace AudioPlayingTest
{
    class AudioPlayChecker
    {
        // Gets the default device for the system
        public static MMDevice GetDefaultRenderDevice()
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            }
        }

        // Returns the current meter.PeakValue;
        public static double PeakValue(MMDevice device)
        {
            using (var meter = AudioMeterInformation.FromDevice(device))
            {
                return meter.PeakValue;
            }
        }

        public static void PrintAvgAudio()
        {
            double oldAvg = 0.1;
            while (true)
            {
                //double sum = 0;
                //for (int i = 0; i < 9; i++)
                //{
                //    sum += PeakValue(GetDefaultRenderDevice());
                //    Thread.Sleep(100);
                //}
                //double Avg = sum / 10;
                //Console.WriteLine(sum / 10);
                //if (Avg / oldAvg > 2)
                //{
                //    Console.WriteLine("Oh no! Please do something to not hurt my ears!");
                //}
                //oldAvg = sum / 10;
                if (PeakValue(GetDefaultRenderDevice()) / oldAvg > 3)
                {
                    Console.WriteLine("Oh no! Please do something to not hurt my ears!");
                }
                oldAvg = PeakValue(GetDefaultRenderDevice());
            }
        }

        static void Main(string[] args)
        {
            PrintAvgAudio();
            Console.ReadLine(); //Just so the console window doesn't close
        }
    }
}