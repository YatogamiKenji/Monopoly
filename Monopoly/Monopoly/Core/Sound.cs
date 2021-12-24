using System;
using System.Windows.Media;

namespace Monopoly
{
    static class Sound
    {
        static MediaPlayer SE = new MediaPlayer();
        static MediaPlayer BGM = new MediaPlayer();
        static double SEV = 1;
        public static void SetSEVolume(double sev)
        {
            SEV = sev;
        }
        public static double GetSEVolume()
        {
            return SEV;
        }
        public static void SetBGMVolume(double bgmv)
        {
            BGM.Volume = bgmv;
        }
        public static double GetBGMVolume()
        {
            return BGM.Volume;
        }
        public static void PlayBGM()
        {
            BGM.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\background.mp3"));
            BGM.Volume = 1;
            BGM.MediaEnded += new EventHandler(BGM_MediaEnded);
            BGM.Play();
        }
        private static void BGM_MediaEnded(object sender, EventArgs e)
        {
            BGM.Position = TimeSpan.Zero;
            BGM.Play();
        }
        public static void StartButton()
        {
            SE.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\buttonStart.mp3"));
            SE.Volume = SEV;
            SE.Play();
        }

        public static void BackButton()
        {
            SE.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\buttonBack.mp3"));
            SE.Volume = SEV;
            SE.Play();
        }

        public static void BuyButton()
        {
            SE.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Buy.mp3"));
            SE.Volume = SEV;
            SE.Play();
        }

        public static void Upgrade()
        {
            SE.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Upgrade.mp3"));
            SE.Volume = SEV;
            SE.Play();
        }

        public static void Spinning()
        {
            new System.Threading.Thread(() =>
            {
                MediaPlayer play = new MediaPlayer();
                play.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\spinning.mp3"));
                play.Volume = SEV;
                play.Play();
            }).Start();
        }

        public static void Type()
        {
            new System.Threading.Thread(() =>
            {
                MediaPlayer play = new MediaPlayer();
                play.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\type.wav"));
                play.Volume = SEV;
                play.Play();
            }).Start();
        }

        public static void ButtonUsePower()
        {
            SE.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Power.mp3"));
            SE.Volume = SEV;
            SE.Play();
        }

        public static void Notification()
        {
            new System.Threading.Thread(() =>
            {
                MediaPlayer play = new MediaPlayer();
                play.Volume = SEV;
                play.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Noti.mp3"));
                play.Play();
            }).Start();
        }

        public static void Planet()
        {
            SE.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Planet.mp3"));
            SE.Volume = SEV;
            SE.Play();
        }

        public static void Player()
        {
            SE.Open(new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Audios\Player.mp3"));
            SE.Volume = SEV;
            SE.Play();
        }
    }
}
