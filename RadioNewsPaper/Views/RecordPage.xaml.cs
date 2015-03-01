using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;

namespace RadioNewsPaper.Views
{
    public partial class RecordPage : PhoneApplicationPage
    {
        //private MicrophoneRecorder _recorder = new MicrophoneRecorder();
        //private IsolatedStorageFileStream _audioStream;
        //private string _tempFileName = "tempWav.wav";
        public RecordPage()
        {
            InitializeComponent();
        }

        //private void startClick(object sender, RoutedEventArgs e)
        //{
        //    recordStartButton.Content = "Stop";
        //    playButton.IsEnabled = false;
        //    _recorder.Start();
        //    recordStartButton.Visibility = Visibility.Collapsed;
        //    recordStopButton.Visibility = Visibility.Visible;
        //}

        //private void SaveTempAudio(MemoryStream buffer)
        //{
        //    if (buffer == null)
        //        throw new ArgumentNullException("Attempting to save an empty audio file");

        //    //Clean media element hold on audioStream
        //    if (_audioStream != null)
        //    {
        //        playAudio.Stop();
        //        playAudio.Source = null;

        //        _audioStream.Dispose();
        //    }

        //    var bytes = buffer.GetWavAsByteArray(_recorder.SampleRate);

        //    using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
        //    {
        //        if (isoStore.FileExists(_tempFileName))
        //        {
        //            isoStore.DeleteFile(_tempFileName);
        //        }
        //        _tempFileName = string.Format("{0}.wav", DateTime.Now.ToFileTime());
        //        _audioStream = isoStore.CreateFile(_tempFileName);
        //        _audioStream.Write(bytes, 0, bytes.Length);

        //        //Play
        //        playAudio.SetSource(_audioStream);

        //        string destFileName = string.Format("/recordAudio/{0}.wav", DateTime.Now.ToFileTime());
        //        using (IsolatedStorageFile isoStoreP = IsolatedStorageFile.GetUserStoreForApplication())
        //        {
        //            if (!isoStoreP.DirectoryExists("/recordAudio/"))
        //                isoStoreP.CreateDirectory("/recordAudio/");
        //            isoStoreP.MoveFile(_tempFileName, destFileName);
        //        }
        //    }
        //}

        //private void playClick(object sender, RoutedEventArgs e)
        //{
        //    playAudio.Play();
        //}

        //private void stopClick(object sender, RoutedEventArgs e)
        //{
        //    recordStopButton.Visibility = Visibility.Collapsed;
        //    recordStartButton.Visibility = Visibility.Visible;
        //    playButton.IsEnabled = true;
        //    _recorder.Stop();
        //    SaveTempAudio(_recorder.Buffer);
            
        //}
    }
}