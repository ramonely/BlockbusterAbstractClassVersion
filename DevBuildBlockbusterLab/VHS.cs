using System;
using System.Collections.Generic;
using System.Text;

namespace DevBuildBlockbusterLab
{
    internal class VHS : Movie
    {
        private int currentTime = 0;

        public VHS(string incomingTitle, Genre incomingCategory, int incomingRunTime, List<string> incomingScenes)
            : base(incomingTitle, incomingCategory, incomingRunTime, incomingScenes)
        {
        }

        public override void Play()
        {
            Console.WriteLine($"Scene {currentTime + 1}: {scenes[currentTime]}");
            currentTime++;

            if (currentTime == Scenes.Count)
            {
                Rewind();
            }

            if (WatchAnotherScene())
            {
                Play();
            }
        }

        public override void PrintScenes()
        {
            PlayWholeMovie();
        }

        public void Rewind()
        {
            currentTime = 0;
        }
    }
}