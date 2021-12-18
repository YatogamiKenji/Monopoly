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
            media.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\buttonStart.mp3"));
            media.Play();
        }

        public static void BackButton()
        {
            media.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\buttonBack.mp3"));
            media.Play();
        }

        public static void BuyButton()
        {
            media.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\Buy.mp3"));
            media.Play();
        }

        public static void Upgrade()
        {
            media.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\Upgrade.mp3"));
            media.Play();
        }

        public static void Spinning()
        {
            new System.Threading.Thread(() =>
            {
                MediaPlayer play = new MediaPlayer();
                play.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\spinning.mp3"));
                play.Play();
            }).Start();
        }

        public static void Type()
        {
            new System.Threading.Thread(() =>
            {
                MediaPlayer play = new MediaPlayer();
                play.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\type.wav"));
                play.Play();
            }).Start();
        }

        public static void ButtonUsePower()
        {
            media.Open(new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Audios\Power.mp3"));
            media.Play();
        }
    }
}
