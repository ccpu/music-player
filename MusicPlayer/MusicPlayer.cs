using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.CloudRail.SI;
using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.ServiceCode.Commands.CodeRedirect;
using Com.CloudRail.SI.Services;
using Com.CloudRail.SI.Types;
using MaterialSkin;
using MaterialSkin.Controls;
using NAudio.Utils;
using NAudio.Wave;

namespace MusicPlayer {


    /**
     * Class MusicPlayer Controller for manager my application 
     */
    public partial class MusicPlayer : MaterialForm {

        private WaveOutEvent waveOutEvent; 
        private Mp3FileReader mp3Reader;
        private List<Track> tracks = new List<Track>();
        
        private Track trackPrevius;
        private Track trackCurrent;
        private Track trackNext;
        
        private Thread threadTrackCurrent;
        private Thread threadSeekBar;
        private Thread threadTimeCurrent;
        
        private delegate Track InfoTrack(List<Track> tracks,int trackId);
        private delegate void changeProgressSeekBar(string trackTitle, int value);
        private delegate void changeProgressLabel(string trackTitle, int value);
        
        private bool loadFilesStatus = false;
        
        public event KeyEventHandler KeyEvent;

        
        /**
         * Class constructor initialize a form and specify theme to use of Material design.
         */
        public MusicPlayer(){
            InitializeComponent();    
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Teal400, Primary.Teal500,
                Primary.Teal100, Accent.LightBlue200,
                TextShade.BLACK
            );
            
        }

        
        /**
         * Base Method for Init, play, Paused a current Track, this method its used over thread (TrackCuurent)
         * and print metadata over form.
         */
        private void TrackPlay(){
            try {

                this.trackTitle.BeginInvoke( new Action(() => { trackTitle.Text = trackCurrent.Title; }) );
                this.trackArtist.BeginInvoke( new Action(() => { trackArtist.Text = trackCurrent.Artist; }) );
                this.trackAlbum.BeginInvoke( new Action(() => { trackAlbum.Text = trackCurrent.Album; }) );
                this.trackDuration.BeginInvoke( new Action(() => { trackDuration.Text = trackCurrent.Duration.ToString(); }) );

                if(File.Exists(trackCurrent.Path+"\\"+trackCurrent.Cover)){
                    this.coverAlbum.BeginInvoke( new Action(() => { coverAlbum.Image = Image.FromFile(trackCurrent.Path+"\\"+trackCurrent.Cover); }) );
                } else { 
                    this.coverAlbum.BeginInvoke( new Action(() => { coverAlbum.Image = Image.FromFile("cover_default.jpg"); }) );
                } 
                
                
                if (waveOutEvent == null) { 
                    waveOutEvent = new WaveOutEvent();
                    mp3Reader = new Mp3FileReader(trackCurrent.Path+"\\"+trackCurrent.File);
                    waveOutEvent.Init(mp3Reader);
                    waveOutEvent.Play();
                 
                    this.buttonPlay.BeginInvoke( new Action(() => { buttonPlay.Image = Image.FromFile("iconPause2.png"); }) );
                } else { 
                    if(waveOutEvent.PlaybackState == PlaybackState.Playing){            
                        waveOutEvent.Pause();
                        this.buttonPlay.BeginInvoke( new Action(() => { buttonPlay.Image = Image.FromFile("iconPlay.png"); }) );        
                    } else if(waveOutEvent.PlaybackState == PlaybackState.Paused){
                        waveOutEvent.Play(); 
                        this.buttonPlay.BeginInvoke( new Action(() => { buttonPlay.Image = Image.FromFile("iconPause2.png"); }) );
                    }
                }
                
            } catch (ThreadAbortException abortException){
                Console.WriteLine((string)abortException.ExceptionState);
            }    
        }

        
        /**
         * Method to create a playlist (List Tracks), loads all audio files from a specified directory.
         */
        private void LoadFileClick(object sender, EventArgs e){
            
            OpenFileDialog openFileDialog = new OpenFileDialog();  
             openFileDialog.Filter = "File Mp3  (*.mp3)|*.mp3;";
             
            if(openFileDialog.ShowDialog() == DialogResult.OK){  

                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                string filePath = fileInfo.DirectoryName;
                string fileName = fileInfo.Name;
                loadFilesStatus = true;
                string[] collectionFiles = Directory.GetFiles(@filePath,"*.mp3");
                List<string> filesList = collectionFiles.ToList();
                int tracksIds = 0;
                foreach (string file in filesList){
                    Track newtrack = new Track();
                    newtrack.Id = tracksIds;
                    newtrack.File = Path.GetFileName(file);
                    newtrack.Path = filePath;
                    newtrack.getMetaDataTrack();
                    tracks.Add(newtrack);
                    tracksIds++;
                }
        
                trackCurrent = tracks.First();
                foreach(Track item in tracks){
                    trackList.Items.Add(item.Title);   
                }
                
            } else { 
                MessageBox.Show("You haven't selected your files yet");
                LoadFileClick(sender,e);
            } 
        }

        /**
         * Method to obtain the information of the previus song.
         */
        static Track GetPreviusTrack(List<Track> tracks, int trackId){
            Track trackSelect = new Track();
            foreach (Track track in tracks){
                if ( trackId > 0 ){
                    if (trackId-1 == track.Id){
                        trackSelect.Id = track.Id;
                        trackSelect.Path = track.Path;
                        trackSelect.File = track.File;
                        trackSelect.Title = track.Title;
                        trackSelect.Cover = track.Cover;
                        trackSelect.Artist = track.Artist;
                        trackSelect.Album = track.Album;
                        trackSelect.Duration = track.Duration;
                    }
                } else { 
                    if ( 0 == track.Id){
                        trackSelect.Id = track.Id;
                        trackSelect.Path = track.Path;
                        trackSelect.File = track.File;
                        trackSelect.Title = track.Title;
                        trackSelect.Cover = track.Cover;
                        trackSelect.Artist = track.Artist;
                        trackSelect.Album = track.Album;
                        trackSelect.Duration = track.Duration;
                    }
                }
            }
            return trackSelect;
        }

        /**
         * Method to obtain the information of the random song.
         */
        static Track GetShuffleTrack(List<Track> tracks, int trackId){
            Track trackSelect = new Track();
            Random random = new Random();
            int rand = random.Next(1,tracks.Count);
            foreach (Track track in tracks){
                if ( rand > 0 && rand < tracks.Count){
                    if (rand == track.Id){
                        trackSelect.Id = track.Id;
                        trackSelect.Path = track.Path;
                        trackSelect.File = track.File;
                        trackSelect.Title = track.Title;
                        trackSelect.Cover = track.Cover;
                        trackSelect.Artist = track.Artist;
                        trackSelect.Album = track.Album;
                        trackSelect.Duration = track.Duration;
                    }
                } 
            }
            return trackSelect;
        }

        /**
         * Method to obtain the information of the following song.
         */
        static Track GetNextTrack(List<Track> tracks, int trackId){
            Track trackSelect = new Track();
            foreach (Track track in tracks){
                if ( trackId >= 0 && trackId < tracks.Count ){
                    if (trackId+1 == track.Id){
                        trackSelect.Id = track.Id;
                        trackSelect.Path = track.Path;
                        trackSelect.File = track.File;
                        trackSelect.Title = track.Title;
                        trackSelect.Cover = track.Cover;
                        trackSelect.Artist = track.Artist;
                        trackSelect.Album = track.Album;
                        trackSelect.Duration = track.Duration;
                    }
                } 
                if ( track.Id >= tracks.Count ){
                    if (tracks.Count-2 == track.Id){
                        trackSelect.Id = track.Id;
                        trackSelect.Path = track.Path;
                        trackSelect.File = track.File;
                        trackSelect.Title = track.Title;
                        trackSelect.Cover = track.Cover;
                        trackSelect.Artist = track.Artist;
                        trackSelect.Album = track.Album;
                        trackSelect.Duration = track.Duration;
                    }
                }
                
            }
            return trackSelect;
        }

        /**
         * Method to pass the current value to the progress bar. 
         */
         private void changeProgress(string text, int value) {
            if (this.InvokeRequired){
                changeProgressSeekBar seekBarDelegate = new changeProgressSeekBar(changeProgress);
                object[] parameters = new object[] { text , value};
                this.Invoke(seekBarDelegate,parameters);
            } else { 
                this.trackSeekBar.Value = value;                
            }
         }

        /**
         * Method to pass the current value to the label current time. 
         */
        private void ChangeProgressLabel(string text, int value) {
            if (this.InvokeRequired){
                changeProgressLabel labelDelegate = new changeProgressLabel(ChangeProgressLabel);
                object[] parameters = new object[] { text , value};
              
                this.Invoke(labelDelegate,parameters);
            } else { 
                this.trackCurrentTime.Text =  text ;                
            }
         }
        
        /**
         * Method to pass the current value to method changeProgress.  
         */
         private void progress(){   
            for (int i = 0; i <= 5000 ; i++){
                changeProgress(Convert.ToString(i), i);
                Thread.Sleep(5000);
            }
         }
        
        /**
         * Method to pass the current value to method changeProgressLabel.  
         */
        private void progressLabel(){   
            int minutes = 0;
            int seconds = 0;
            string format = Convert.ToString(minutes) + ":" + Convert.ToString(seconds); 
            for (int i = 0;  ; i++){
                format = Convert.ToString(minutes) + ":" + Convert.ToString(seconds);
                if (seconds==60){
                    seconds = 0;
                    minutes++;
                }
                ChangeProgressLabel(format, i);
                seconds++;
                Thread.Sleep(1000);
            }
        }

        /**
         *  Main method to start, play, pause the current song,
         *  managing the 3 main threads trackCurrent, seekbar, timeCurrent
         */
        private void PlayMusic(){
            
            trackCurrent.getMetaDataTrack();   
            if ( waveOutEvent == null ) {  
                ThreadStart threadStartTrack = new ThreadStart(TrackPlay);
                threadTrackCurrent = new Thread(threadStartTrack);
                ThreadStart threadStartSeekBar = new ThreadStart(progress);
                threadSeekBar = new Thread(threadStartSeekBar);
                ThreadStart threadStarTimeCurrent = new ThreadStart(progressLabel);
                threadTimeCurrent = new Thread(threadStarTimeCurrent);
                threadTrackCurrent.Start();
                threadSeekBar.Start();
                threadTimeCurrent.Start();
            } else {
                
                if( waveOutEvent.PlaybackState == PlaybackState.Playing ){  
                    waveOutEvent.Pause();
                    if(threadTrackCurrent.ThreadState == ThreadState.Running) { 
                        threadTrackCurrent.Suspend();
                        threadSeekBar.Suspend();
                        threadTimeCurrent.Suspend();
                    }
                        
                     buttonPlay.Image = Image.FromFile("iconPlay.png"); 
                } else if( waveOutEvent.PlaybackState == PlaybackState.Paused){  
                    if(threadTrackCurrent.ThreadState == ThreadState.Suspended) { 
                        threadTrackCurrent.Resume();
                        threadSeekBar.Resume();
                        threadTimeCurrent.Resume();
                    }
                        
                    waveOutEvent.Play();
                    buttonPlay.Image = Image.FromFile("iconPause2.png");
                    
                } 
            }
        }

        /**
         * Pause the current song and start playing the selected song. 
         */
        private void TrackListIndexChanged(object sender, EventArgs e){
          if (waveOutEvent!=null){
                if(waveOutEvent.PlaybackState == PlaybackState.Playing) {
                    waveOutEvent.Pause();
                    waveOutEvent = new WaveOutEvent();
                }
            
            if(trackList.SelectedItems.Count > 0) { 
                 string item = trackList.SelectedItems[0].Text;
                 foreach(Track track in tracks){
                    if(item == track.Title) {
                        if(waveOutEvent.PlaybackState == PlaybackState.Playing){  
                            waveOutEvent.Pause();
                            buttonPlay.Image = Image.FromFile("iconPlay.png");
                            if (threadTrackCurrent.ThreadState == ThreadState.Running){ 
                                 threadTimeCurrent.Abort();
                                 threadSeekBar.Abort();
                                 threadTrackCurrent.Abort();
                                    
                            }
                            
                        } else if(waveOutEvent.PlaybackState == PlaybackState.Paused){
                            if (threadTrackCurrent.ThreadState == ThreadState.Aborted || threadTrackCurrent.ThreadState == ThreadState.Suspended) { 
                                threadTrackCurrent.Start();
                                threadSeekBar.Start();
                                threadTimeCurrent.Start();
                            
                            }
                            waveOutEvent.Play(); 
                            buttonPlay.Image = Image.FromFile("iconPause2.png");     
                        }
                        waveOutEvent.Dispose();
                        waveOutEvent = null;
                        trackCurrent = null;
                        trackCurrent = new Track();
                        trackCurrent.File = track.File;
                        trackCurrent.Path = track.Path;        
                        trackCurrent.getMetaDataTrack();
                        PlayMusic();
                        
                    }
                 }           
            }
          }
        }

        /**
         * Click on the Play button and call the PlayMusic() method 
         */
        private void PlayClick(object sender, EventArgs e){
            if (loadFilesStatus == true){
                PlayMusic();
            } else { 
                MessageBox.Show("You haven't selected your files yet");
                LoadFileClick(sender,e);
            }  
        }
        
        /**
         * Click on the Next button Abort track current and update track current with next track init and play song  
         */
        private void NextClick(object sender, EventArgs e){
           if (waveOutEvent!=null){
             if(waveOutEvent.PlaybackState == PlaybackState.Playing) {
                threadTrackCurrent.Abort();
                waveOutEvent.Pause();
                waveOutEvent = new WaveOutEvent();
             }
             string item = trackCurrent.Title;
             foreach(Track track in tracks){
                 if(item == track.Title) {
                     if(waveOutEvent.PlaybackState == PlaybackState.Playing){  
                         waveOutEvent.Pause();
                        if (threadTrackCurrent.ThreadState == ThreadState.Running) { 
                            threadTimeCurrent.Abort();
                             threadSeekBar.Abort();
                             threadTrackCurrent.Abort();
                        }
                        buttonPlay.Image = Image.FromFile("iconPlay.png");  
                     } else if(waveOutEvent.PlaybackState == PlaybackState.Paused){
                        if (threadTrackCurrent.ThreadState == ThreadState.Aborted || threadTrackCurrent.ThreadState == ThreadState.Suspended) { 
                            threadTrackCurrent.Start();
                            threadSeekBar.Start();
                            threadTimeCurrent.Start();
                        }
                        waveOutEvent.Play(); 
                        buttonPlay.Image = Image.FromFile("iconPause2.png");     
                     }
                    waveOutEvent.Dispose();
                    waveOutEvent = null;
                    trackCurrent = null;
                     
                    InfoTrack nextTrack = new InfoTrack(GetNextTrack);
                    trackNext = nextTrack(tracks,track.Id);
                        
                    trackCurrent = new Track();
                    trackCurrent.File = trackNext.File;
                    trackCurrent.Path = trackNext.Path;        
                    trackCurrent.getMetaDataTrack();
                    PlayMusic();

                }
            }  
          }
        }
        /**
         * Click on the Next previus Abort track current and update track current with previus track init and play song  
         */
        private void PreviusClick(object sender, EventArgs e){
          if (waveOutEvent!=null){
             if(waveOutEvent.PlaybackState == PlaybackState.Playing) {
                waveOutEvent.Pause();
                waveOutEvent = new WaveOutEvent();
             }
             string item = trackCurrent.Title;
             foreach(Track track in tracks){
                 if(item == track.Title) {
                     if(waveOutEvent.PlaybackState == PlaybackState.Playing){  
                         waveOutEvent.Pause();
                        if (threadTrackCurrent.ThreadState == ThreadState.Running) { 
                            threadTrackCurrent.Abort();
                            threadSeekBar.Abort();
                            threadTimeCurrent.Abort();
                        }
                         buttonPlay.Image = Image.FromFile("iconPlay.png");  
                     } else if(waveOutEvent.PlaybackState == PlaybackState.Paused){
                        if (threadTrackCurrent.ThreadState == ThreadState.Aborted || threadTrackCurrent.ThreadState == ThreadState.Suspended) { 
                            threadTrackCurrent.Start();
                            threadSeekBar.Start();
                            threadTimeCurrent.Start();
                        }
                         waveOutEvent.Play(); 
                         buttonPlay.Image = Image.FromFile("iconPause2.png");     
                     }
                     waveOutEvent.Dispose();
                     waveOutEvent = null;
                     trackCurrent = null;
                     
                    InfoTrack previusTrack = new InfoTrack(GetPreviusTrack);
                    trackPrevius = previusTrack(tracks,track.Id);
                        
                    trackCurrent = new Track();
                    trackCurrent.File = trackPrevius.File;
                    trackCurrent.Path = trackPrevius.Path;        
                    trackCurrent.getMetaDataTrack();
                    PlayMusic();

                 }
             }
            }
        }

        /**
         * Click on the Next button Abort track current and update track current with random track init and play song  
         */
        private void ShuffleClick(object sender, EventArgs e){
          if (waveOutEvent!=null){
            if(waveOutEvent.PlaybackState == PlaybackState.Playing) {
                waveOutEvent.Pause();
                waveOutEvent = new WaveOutEvent();
            }
            string item = trackCurrent.Title;
            foreach(Track track in tracks){
                 if(item == track.Title) {
                     if(waveOutEvent.PlaybackState == PlaybackState.Playing){  
                         waveOutEvent.Pause();
                        if (threadTrackCurrent.ThreadState == ThreadState.Running) { 
                            threadTrackCurrent.Abort();
                             threadSeekBar.Abort();
                             threadTimeCurrent.Abort();
                        }
                        buttonPlay.Image = Image.FromFile("iconPlay.png");  
                     } else if(waveOutEvent.PlaybackState == PlaybackState.Paused){
                        if (threadTrackCurrent.ThreadState == ThreadState.Aborted || threadTrackCurrent.ThreadState == ThreadState.Suspended) { 
                            threadTrackCurrent.Start();
                            threadSeekBar.Start();
                            threadTimeCurrent.Start();
                        }
                        waveOutEvent.Play(); 
                        buttonPlay.Image = Image.FromFile("iconPause2.png");     
                     }
                    waveOutEvent.Dispose();
                    waveOutEvent = null;
                    trackCurrent = null;
                     
                    InfoTrack shuffleTrack = new InfoTrack(GetShuffleTrack);
                    trackNext = shuffleTrack(tracks,track.Id);
                        
                    trackCurrent = new Track();
                    trackCurrent.File = trackNext.File;
                    trackCurrent.Path = trackNext.Path;        
                    trackCurrent.getMetaDataTrack();
                    PlayMusic();

                }
            }
          }  
        }

            
       /**
         * Method to obtain the information of the searched song.
         */        
        static Track GetTrackSearch(List<Track> tracks, int trackId){
            Track trackSelect = new Track();
            foreach (Track track in tracks){
                if ( trackId > 0 && trackId <= tracks.Count ){
                    if (trackId == track.Id){
                        trackSelect.Id = track.Id;
                        trackSelect.Path = track.Path;
                        trackSelect.File = track.File;
                        trackSelect.Title = track.Title;
                        trackSelect.Cover = track.Cover;
                        trackSelect.Artist = track.Artist;
                        trackSelect.Album = track.Album;
                        trackSelect.Duration = track.Duration;
                    }
                }
            }
            return trackSelect;
        }

        /**
         * Click on the search button Abort track current and update track current with searched track init and play song  
         */
        private void SearchClick(object sender, EventArgs e){
            bool trackFound = false;
            if (waveOutEvent!=null){
            string item = textFieldSearch.Text;
            foreach(Track track in tracks){
                 if(item == track.Title) {
                     trackFound = true;
                        if(waveOutEvent.PlaybackState == PlaybackState.Playing){  
                         waveOutEvent.Pause();
                          waveOutEvent = new WaveOutEvent();
                        if (threadTrackCurrent.ThreadState == ThreadState.Running) { 
                            threadTrackCurrent.Abort();
                             threadSeekBar.Abort();
                             threadTimeCurrent.Abort();
                        }
                        buttonPlay.Image = Image.FromFile("iconPlay.png");  
                     } else if(waveOutEvent.PlaybackState == PlaybackState.Paused){
                        if (threadTrackCurrent.ThreadState == ThreadState.Aborted || threadTrackCurrent.ThreadState == ThreadState.Suspended) { 
                            threadTrackCurrent.Start();
                            threadSeekBar.Start();
                            threadTimeCurrent.Start();
                        }
                        waveOutEvent.Play(); 
                        buttonPlay.Image = Image.FromFile("iconPause2.png");     
                     }
                    waveOutEvent.Dispose();
                    waveOutEvent = null;
                    trackCurrent = null;
                     
                    InfoTrack searchTrack = new InfoTrack(GetTrackSearch);
                    trackNext = searchTrack(tracks,track.Id);
                        
                    trackCurrent = new Track();
                    trackCurrent.File = trackNext.File;
                    trackCurrent.Path = trackNext.Path;        
                    trackCurrent.getMetaDataTrack();
                    PlayMusic();

                }
            }
          }
            if (!trackFound){MessageBox.Show("The song you are looking for was not found");}
        }

        
    }
}
 
