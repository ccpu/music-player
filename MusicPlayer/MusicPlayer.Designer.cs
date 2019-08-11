namespace MusicPlayer
{
    partial class MusicPlayer
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.trackCurrentTime = new MaterialSkin.Controls.MaterialLabel();
            this.trackDuration = new MaterialSkin.Controls.MaterialLabel();
            this.trackAlbum = new MaterialSkin.Controls.MaterialLabel();
            this.trackArtist = new MaterialSkin.Controls.MaterialLabel();
            this.trackTitle = new MaterialSkin.Controls.MaterialLabel();
            this.coverAlbum = new System.Windows.Forms.PictureBox();
            this.panelListTracks = new System.Windows.Forms.Panel();
            this.trackList = new MaterialSkin.Controls.MaterialListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.trackSeekBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.buttonLoadFiles = new System.Windows.Forms.PictureBox();
            this.buttonShuffle = new System.Windows.Forms.PictureBox();
            this.buttonPrevius = new System.Windows.Forms.PictureBox();
            this.buttonNext = new System.Windows.Forms.PictureBox();
            this.buttonPlay = new System.Windows.Forms.PictureBox();
            this.textFieldSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.iconSearch = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverAlbum)).BeginInit();
            this.panelListTracks.SuspendLayout();
            this.panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonShuffle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPrevius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.AutoSize = true;
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.panelHeader.Controls.Add(this.trackCurrentTime);
            this.panelHeader.Controls.Add(this.trackDuration);
            this.panelHeader.Controls.Add(this.trackAlbum);
            this.panelHeader.Controls.Add(this.trackArtist);
            this.panelHeader.Controls.Add(this.trackTitle);
            this.panelHeader.Controls.Add(this.coverAlbum);
            this.panelHeader.Location = new System.Drawing.Point(0, 62);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(373, 108);
            this.panelHeader.TabIndex = 0;
            // 
            // trackCurrentTime
            // 
            this.trackCurrentTime.AutoSize = true;
            this.trackCurrentTime.Depth = 0;
            this.trackCurrentTime.Font = new System.Drawing.Font("Roboto", 11F);
            this.trackCurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.trackCurrentTime.Location = new System.Drawing.Point(287, 68);
            this.trackCurrentTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.trackCurrentTime.Name = "trackCurrentTime";
            this.trackCurrentTime.Size = new System.Drawing.Size(45, 19);
            this.trackCurrentTime.TabIndex = 5;
            this.trackCurrentTime.Text = "00:00";
            // 
            // trackDuration
            // 
            this.trackDuration.AutoSize = true;
            this.trackDuration.Depth = 0;
            this.trackDuration.Font = new System.Drawing.Font("Roboto", 11F);
            this.trackDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.trackDuration.Location = new System.Drawing.Point(115, 68);
            this.trackDuration.MouseState = MaterialSkin.MouseState.HOVER;
            this.trackDuration.Name = "trackDuration";
            this.trackDuration.Size = new System.Drawing.Size(45, 19);
            this.trackDuration.TabIndex = 4;
            this.trackDuration.Text = "00:00";
            // 
            // trackAlbum
            // 
            this.trackAlbum.AutoSize = true;
            this.trackAlbum.Depth = 0;
            this.trackAlbum.Font = new System.Drawing.Font("Roboto", 11F);
            this.trackAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.trackAlbum.Location = new System.Drawing.Point(115, 49);
            this.trackAlbum.MouseState = MaterialSkin.MouseState.HOVER;
            this.trackAlbum.Name = "trackAlbum";
            this.trackAlbum.Size = new System.Drawing.Size(52, 19);
            this.trackAlbum.TabIndex = 3;
            this.trackAlbum.Text = "Album";
            // 
            // trackArtist
            // 
            this.trackArtist.AutoSize = true;
            this.trackArtist.Depth = 0;
            this.trackArtist.Font = new System.Drawing.Font("Roboto", 11F);
            this.trackArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.trackArtist.Location = new System.Drawing.Point(115, 30);
            this.trackArtist.MouseState = MaterialSkin.MouseState.HOVER;
            this.trackArtist.Name = "trackArtist";
            this.trackArtist.Size = new System.Drawing.Size(46, 19);
            this.trackArtist.TabIndex = 2;
            this.trackArtist.Text = "Artist";
            // 
            // trackTitle
            // 
            this.trackTitle.AutoSize = true;
            this.trackTitle.Depth = 0;
            this.trackTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.trackTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.trackTitle.Location = new System.Drawing.Point(115, 11);
            this.trackTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.trackTitle.Name = "trackTitle";
            this.trackTitle.Size = new System.Drawing.Size(39, 19);
            this.trackTitle.TabIndex = 1;
            this.trackTitle.Text = "Title";
            // 
            // coverAlbum
            // 
            this.coverAlbum.Image = ((System.Drawing.Image)(resources.GetObject("coverAlbum.Image")));
            this.coverAlbum.Location = new System.Drawing.Point(0, 0);
            this.coverAlbum.Name = "coverAlbum";
            this.coverAlbum.Size = new System.Drawing.Size(109, 105);
            this.coverAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverAlbum.TabIndex = 0;
            this.coverAlbum.TabStop = false;
            // 
            // panelListTracks
            // 
            this.panelListTracks.AutoSize = true;
            this.panelListTracks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panelListTracks.Controls.Add(this.trackList);
            this.panelListTracks.Location = new System.Drawing.Point(0, 166);
            this.panelListTracks.Name = "panelListTracks";
            this.panelListTracks.Size = new System.Drawing.Size(373, 191);
            this.panelListTracks.TabIndex = 1;
            // 
            // trackList
            // 
            this.trackList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.trackList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Artist,
            this.Album,
            this.Duration});
            this.trackList.Depth = 0;
            this.trackList.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.trackList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.trackList.FullRowSelect = true;
            this.trackList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.trackList.Location = new System.Drawing.Point(0, 0);
            this.trackList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.trackList.MouseState = MaterialSkin.MouseState.OUT;
            this.trackList.Name = "trackList";
            this.trackList.OwnerDraw = true;
            this.trackList.Size = new System.Drawing.Size(370, 179);
            this.trackList.TabIndex = 0;
            this.trackList.UseCompatibleStateImageBehavior = false;
            this.trackList.View = System.Windows.Forms.View.Details;
            this.trackList.SelectedIndexChanged += new System.EventHandler(this.TrackListIndexChanged);
            // 
            // Title
            // 
            this.Title.Tag = "Title";
            this.Title.Text = "Title";
            this.Title.Width = 156;
            // 
            // Artist
            // 
            this.Artist.Tag = "Artist";
            this.Artist.Text = "Artist";
            this.Artist.Width = 76;
            // 
            // Album
            // 
            this.Album.Tag = "Album";
            this.Album.Text = "Album";
            this.Album.Width = 62;
            // 
            // Duration
            // 
            this.Duration.Tag = "Duration";
            this.Duration.Text = "Duration";
            this.Duration.Width = 75;
            // 
            // panelPlayer
            // 
            this.panelPlayer.AutoSize = true;
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(42)))));
            this.panelPlayer.Controls.Add(this.trackSeekBar);
            this.panelPlayer.Controls.Add(this.buttonLoadFiles);
            this.panelPlayer.Controls.Add(this.buttonShuffle);
            this.panelPlayer.Controls.Add(this.buttonPrevius);
            this.panelPlayer.Controls.Add(this.buttonNext);
            this.panelPlayer.Controls.Add(this.buttonPlay);
            this.panelPlayer.Location = new System.Drawing.Point(0, 350);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(376, 100);
            this.panelPlayer.TabIndex = 2;
            // 
            // trackSeekBar
            // 
            this.trackSeekBar.Depth = 0;
            this.trackSeekBar.Location = new System.Drawing.Point(0, 31);
            this.trackSeekBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.trackSeekBar.Name = "trackSeekBar";
            this.trackSeekBar.Size = new System.Drawing.Size(373, 5);
            this.trackSeekBar.TabIndex = 1;
            // 
            // buttonLoadFiles
            // 
            this.buttonLoadFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoadFiles.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadFiles.Image")));
            this.buttonLoadFiles.Location = new System.Drawing.Point(46, 49);
            this.buttonLoadFiles.Name = "buttonLoadFiles";
            this.buttonLoadFiles.Size = new System.Drawing.Size(40, 40);
            this.buttonLoadFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonLoadFiles.TabIndex = 5;
            this.buttonLoadFiles.TabStop = false;
            this.buttonLoadFiles.Click += new System.EventHandler(this.LoadFileClick);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShuffle.Image = ((System.Drawing.Image)(resources.GetObject("buttonShuffle.Image")));
            this.buttonShuffle.Location = new System.Drawing.Point(292, 48);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(40, 40);
            this.buttonShuffle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonShuffle.TabIndex = 4;
            this.buttonShuffle.TabStop = false;
            this.buttonShuffle.Click += new System.EventHandler(this.ShuffleClick);
            // 
            // buttonPrevius
            // 
            this.buttonPrevius.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrevius.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrevius.Image")));
            this.buttonPrevius.Location = new System.Drawing.Point(103, 48);
            this.buttonPrevius.Name = "buttonPrevius";
            this.buttonPrevius.Size = new System.Drawing.Size(40, 40);
            this.buttonPrevius.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonPrevius.TabIndex = 3;
            this.buttonPrevius.TabStop = false;
            this.buttonPrevius.Click += new System.EventHandler(this.PreviusClick);
            // 
            // buttonNext
            // 
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(229, 49);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(40, 40);
            this.buttonNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonNext.TabIndex = 2;
            this.buttonNext.TabStop = false;
            this.buttonNext.Click += new System.EventHandler(this.NextClick);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(166, 48);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(40, 40);
            this.buttonPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.TabStop = false;
            this.buttonPlay.Click += new System.EventHandler(this.PlayClick);
            // 
            // textFieldSearch
            // 
            this.textFieldSearch.Depth = 0;
            this.textFieldSearch.Hint = "";
            this.textFieldSearch.Location = new System.Drawing.Point(142, 33);
            this.textFieldSearch.MaxLength = 32767;
            this.textFieldSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.textFieldSearch.Name = "textFieldSearch";
            this.textFieldSearch.PasswordChar = '\0';
            this.textFieldSearch.SelectedText = "";
            this.textFieldSearch.SelectionLength = 0;
            this.textFieldSearch.SelectionStart = 0;
            this.textFieldSearch.Size = new System.Drawing.Size(166, 23);
            this.textFieldSearch.TabIndex = 1;
            this.textFieldSearch.TabStop = false;
            this.textFieldSearch.Text = "Search Some Song";
            this.textFieldSearch.UseSystemPasswordChar = false;
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.Transparent;
            this.iconSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconSearch.Image = ((System.Drawing.Image)(resources.GetObject("iconSearch.Image")));
            this.iconSearch.Location = new System.Drawing.Point(320, 33);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Size = new System.Drawing.Size(27, 23);
            this.iconSearch.TabIndex = 6;
            this.iconSearch.TabStop = false;
            this.iconSearch.Click += new System.EventHandler(this.SearchClick);
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 450);
            this.Controls.Add(this.iconSearch);
            this.Controls.Add(this.textFieldSearch);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.panelListTracks);
            this.Controls.Add(this.panelHeader);
            this.Name = "MusicPlayer";
            this.Opacity = 0.9D;
            this.Text = "MusicPlayer";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverAlbum)).EndInit();
            this.panelListTracks.ResumeLayout(false);
            this.panelPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonShuffle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPrevius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelListTracks;
        private System.Windows.Forms.Panel panelPlayer;
        private MaterialSkin.Controls.MaterialLabel trackDuration;
        private MaterialSkin.Controls.MaterialLabel trackAlbum;
        private MaterialSkin.Controls.MaterialLabel trackArtist;
        private MaterialSkin.Controls.MaterialLabel trackTitle;
        private System.Windows.Forms.PictureBox coverAlbum;
        private MaterialSkin.Controls.MaterialListView trackList;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader Album;
        private System.Windows.Forms.ColumnHeader Duration;
        private System.Windows.Forms.PictureBox buttonPrevius;
        private System.Windows.Forms.PictureBox buttonNext;
        private System.Windows.Forms.PictureBox buttonPlay;
        private System.Windows.Forms.PictureBox buttonLoadFiles;
        private System.Windows.Forms.PictureBox buttonShuffle;
        private MaterialSkin.Controls.MaterialLabel trackCurrentTime;
        private MaterialSkin.Controls.MaterialProgressBar trackSeekBar;
        private MaterialSkin.Controls.MaterialSingleLineTextField textFieldSearch;
        private System.Windows.Forms.PictureBox iconSearch;
    }
}

