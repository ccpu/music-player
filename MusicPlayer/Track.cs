using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MusicPlayer {
    
    /**
     * Class Track model for audio files 
     */
    class Track {
        
        private int id;
        private string path;
        private string file;
        private string title;
        private string cover;
        private string artist;
        private string album;
        private TimeSpan duration; 

        /**
         * Class constructor specifying attributes empty.
         */
        public Track(){
            this.id = new int();
            this.path = "";
            this.file = "";
            this.title = "";
            this.cover = "";
            this.artist = "";
            this.album = "";
            this.duration = new TimeSpan();
        }

        /**
         * Class constructor specifying attributes with their respective values.
         */
        public Track(string pt,string fl, string nm,string cv, string at,string ab, TimeSpan tm){
            this.path = pt;
            this.file = fl;
            this.title = nm;
            this.cover = cv;
            this.artist = at;
            this.album = ab;
            this.duration = tm;
        }

        /**
         * Getters and Setters of attributes.
         */
        public int Id {
            set { this.id = value; }
            get { return this.id; }
        }

        public string Path {
            set { this.path = value; }
            get { return this.path; }
        }

        public string File {
            set { this.file = value; }
            get { return this.file; }
        }

        public string Title {
            set { this.title = value; }
            get { return this.title; }
        }
        
        public string Cover {
            set { this.cover = value; }
            get { return this.cover; }
        }

        public string Artist {
            set { this.artist = value; }
            get { return this.artist; }
        }

        public string Album {
            set { this.album = value; }
            get { return this.album; }
        }

        public TimeSpan Duration {
            set { this.duration = value; }
            get { return this.duration; }
        }

        /**
         * Get MetaData of audio file for update attributes
         */
        public void getMetaDataTrack(){
                var metaDataFileMp3 = TagLib.File.Create(this.path+"\\"+this.file); 
                this.title = metaDataFileMp3.Tag.Title;
                this.artist = metaDataFileMp3.Tag.FirstAlbumArtist;
                this.album = metaDataFileMp3.Tag.Album;
                this.duration = metaDataFileMp3.Properties.Duration;
                this.cover = metaDataFileMp3.Tag.Album+".jpg";
                
        }
        

    }

}
