using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using Timer = System.Windows.Forms.Timer;


namespace Music_Player_App
{

    internal class AudioHandler
    {
        private WaveOutEvent waveOutEvent;
        private RawSourceWaveStream provider;

        public AudioHandler(byte[] audioData) 
        {
            provider = new RawSourceWaveStream(new MemoryStream(audioData), new WaveFormat());
            waveOutEvent = new WaveOutEvent();
        }

        public void PlayAudio()
        {
            StopAudio();

            waveOutEvent.Init(provider);
            waveOutEvent.Play();
        }

        public double GetProgress()
        {
            // Calculate progress percentage
            TimeSpan currentPosition = provider.CurrentTime;

            // Calculate the progress as a percentage
            return currentPosition.TotalMilliseconds / provider.TotalTime.TotalMilliseconds;
        }

        public void PauseAudio() => waveOutEvent?.Pause();


        public void ResumeAudio() => waveOutEvent?.Play();

        public void StopAudio()
        {
            waveOutEvent?.Stop();
            waveOutEvent?.Dispose();
            provider?.Dispose();
        }

        public void RestartAudio()
        {
            provider.CurrentTime = TimeSpan.Zero;
            waveOutEvent?.Play();            
        }

        public PlaybackState GetAudioPlaybackState()
        {
            if (waveOutEvent != null)
            {
                return waveOutEvent.PlaybackState;
            }
            return PlaybackState.Stopped;
        }
    }
}
