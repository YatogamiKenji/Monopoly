using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Monopoly
{
    static class Sound
    {
        static MediaPlayer media = new MediaPlayer();

        public static void StartButton()
        {
            media.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\buttonStart.mp3"));
            media.Play();
        }

        public static void BackButton()
        {
            media.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\buttonBack.mp3"));
            media.Play();
        }

        public static void BuyButton()
        {
            media.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Buy.mp3"));
            media.Play();
        }

        public static void Upgrade()
        {
            media.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Upgrade.mp3"));
            media.Play();
        }

        public static void Spinning()
        {
            new System.Threading.Thread(() =>
            {
                MediaPlayer play = new MediaPlayer();
                play.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\spinning.mp3"));
                play.Play();
            }).Start();
        }

        public static void Type()
        {
            new System.Threading.Thread(() =>
            {
                MediaPlayer play = new MediaPlayer();
                play.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\type.wav"));
                play.Play();
            }).Start();
        }

        public static void ButtonUsePower()
        {
            media.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Power.mp3"));
            media.Play();
        }
    }
}
