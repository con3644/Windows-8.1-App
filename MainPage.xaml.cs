using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

/// <summary>
/// This program is a musician's tool for practicing rhythmic dictation. Notes are randomly played and the user must guess which notes are played
/// by clicking the corresponding button.
/// </summary>

//this is the codebehind for the main page UI of the Rhythmic Dictation App

namespace Rhythmic_Dictation
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        int tempo, msPerBeat, msPerMeasure; //determines the timing of the measures
        int beatNum, beatsLeft; //beatsLeft determines beats left per measure and beatNum is a incrementing counter for the current beat
        int counter = 1, decCounter = 1; //counters used for drawing and erasing note images
        DispatcherTimer aTimer;

        public void Processor()
        {
            beatNum = 1;

            aTimer = new DispatcherTimer(); //timer used to determine length of beat and when to play a note
            tempo = 80;

            int msPerBeat = PerBeat(tempo);
            aTimer.Tick += ATimer_Tick;

            int msPerMeasure = PerMeasure(tempo);
            aTimer.Start();
        }

        public void ATimer_Tick(object sender, object e)
        {
            if (beatNum > 4) //set total number of beats for all measure
            {
                aTimer.Stop();
            }
            else
            {            
                ChooseNote();
                aTimer.Interval = new TimeSpan(0, 0, 0, 0, 750);   //interval set for length of longest note + .25 seconds    
                beatNum++;
                
            }
        }

        public void ChooseNote()
        {

            //set the media elements to zero for playing
            quarter.Position = TimeSpan.Zero;
            eighth.Position = TimeSpan.Zero;
            sixteenth.Position = TimeSpan.Zero;
            dottedQuarter.Position = TimeSpan.Zero;
            twoEighthOneSixteenth.Position = TimeSpan.Zero;
            twoEighth.Position = TimeSpan.Zero;
            twoSixteenthOneEighth.Position = TimeSpan.Zero;
            fourEighth.Position = TimeSpan.Zero;
            fourSixteenth.Position = TimeSpan.Zero;


            Random random = new Random(); //random numbers for choosing notes
            int rInt = random.Next(3,13);  //only 3 - 13 for starting difficulty


            switch (rInt)
            {
                case 1: 
                    whole.Play();    //whole and half notes removed as they are too easy to distinguish from the rest
                    break;

                case 2: 
                    half.Play();
                    break;

                case 3: 
                    quarter.Play();
                    break;

                case 4:
                    eighth.Play();
                    break;

                case 5:
                    sixteenth.Play();
                    break;

                case 6: 
                    dottedQuarter.Play();
                    break;

                case 7: //eighth rest note
                        //do nothing for rest
                    break;

                case 8: 
                    twoEighthOneSixteenth.Play();
                    break;

                case 9:
                    twoEighth.Play();
                    break;

                case 10:
                    twoSixteenth.Play();
                    break;

                case 11:
                    twoSixteenthOneEighth.Play();
                    break;

                case 12:
                    fourEighth.Play();
                    break;

                case 13:
                    fourSixteenth.Play();
                    break;

                case 14: //dotted half note
                    dottedHalf.Play();   //dottedhalf has been removed until higher difficulties are implemented
                    break;

                default:
                    break;
            }
        }

        private void EighthRestButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public int PerBeat(int tempo)
        {

            switch (tempo)
            {
                case 80:
                    msPerBeat = 750;
                    break;
                case 120:
                    msPerBeat = 500;
                    break;
                case 150:
                    msPerBeat = 400;
                    break;
            }
            return msPerBeat;
        }

        public int PerMeasure(int tempo)
        {

            switch (tempo)
            {
                case 80:
                    msPerMeasure = 3000;
                    break;
                case 120:
                    msPerMeasure = 2000;
                    break;
                case 150:
                    msPerMeasure = 1600;
                    break;
            }
            return msPerMeasure;
        }

        private void Quarter_Clicked(object sender, RoutedEventArgs e)
        { 
            string path = "Asset/Quarter.png";
            Counter(path, 0);

        }
        private void Eighth_Clicked(object sender, RoutedEventArgs e)
        {
            string path = "Asset/Eighth.png";
            Counter(path, 0);
        }
        private void Sixteenth_Clicked(object sender, RoutedEventArgs e)
        {
            string path = "Asset/Sixteenth.png";
            Counter(path, 0);
        }
        private void DottedQuarter_Clicked(object sender, RoutedEventArgs e)
        {
            string path = "Asset/DottedQuarter.png";
            Counter(path, 0);
        }
        private void EighthRest_Clicked(object sender, RoutedEventArgs e)
        {
            string path = "Asset/EighthRest.png";
            Counter(path, 0);
        }
        private void Counter(string paths, int state) // Draws note image from Asset to corresponding empty image on UI
        {
            int switchCounter;
            if (state == 0) //adding note images
            {
                switchCounter = counter; //use increment counter
            }
            else //removing note images for undo button
            {
                switchCounter = decCounter; //use decrement counter
            }
            switch (switchCounter)
            {
                case 1:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage1 = new BitmapImage();
                        img1.Width = bitmapImage1.DecodePixelWidth = 80;
                        bitmapImage1.UriSource = new Uri(img1.BaseUri, paths);
                        img1.Source = bitmapImage1;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img1.Source = null;
                        counter = 1;
                    }
                    break;
                case 2:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage2 = new BitmapImage();
                        img2.Width = bitmapImage2.DecodePixelWidth = 80;
                        bitmapImage2.UriSource = new Uri(img2.BaseUri, paths);
                        img2.Source = bitmapImage2;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img2.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 3:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage3 = new BitmapImage();
                        img3.Width = bitmapImage3.DecodePixelWidth = 80;
                        bitmapImage3.UriSource = new Uri(img3.BaseUri, paths);
                        img3.Source = bitmapImage3;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img3.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 4:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage4 = new BitmapImage();
                        img4.Width = bitmapImage4.DecodePixelWidth = 80;
                        bitmapImage4.UriSource = new Uri(img4.BaseUri, paths);
                        img4.Source = bitmapImage4;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img4.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 5:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage5 = new BitmapImage();
                        img5.Width = bitmapImage5.DecodePixelWidth = 80;
                        bitmapImage5.UriSource = new Uri(img5.BaseUri, paths);
                        img5.Source = bitmapImage5;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img5.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 6:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage6 = new BitmapImage();
                        img6.Width = bitmapImage6.DecodePixelWidth = 80;
                        bitmapImage6.UriSource = new Uri(img6.BaseUri, paths);
                        img6.Source = bitmapImage6;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img6.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 7:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage7 = new BitmapImage();
                        img7.Width = bitmapImage7.DecodePixelWidth = 80;
                        bitmapImage7.UriSource = new Uri(img7.BaseUri, paths);
                        img7.Source = bitmapImage7;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img7.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 8:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage8 = new BitmapImage();
                        img8.Width = bitmapImage8.DecodePixelWidth = 80;
                        bitmapImage8.UriSource = new Uri(img8.BaseUri, paths);
                        img8.Source = bitmapImage8;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img8.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 9:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage9 = new BitmapImage();
                        img9.Width = bitmapImage9.DecodePixelWidth = 80;
                        bitmapImage9.UriSource = new Uri(img9.BaseUri, paths);
                        img9.Source = bitmapImage9;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img9.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 10:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage10 = new BitmapImage();
                        img10.Width = bitmapImage10.DecodePixelWidth = 80;
                        bitmapImage10.UriSource = new Uri(img10.BaseUri, paths);
                        img10.Source = bitmapImage10;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img10.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 11:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage11 = new BitmapImage();
                        img11.Width = bitmapImage11.DecodePixelWidth = 80;
                        bitmapImage11.UriSource = new Uri(img11.BaseUri, paths);
                        img11.Source = bitmapImage11;
                        counter++;
                        decCounter = counter - 1;
                    }
                    else
                    {
                        img11.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
                case 12:
                    if (state == 0)
                    {
                        BitmapImage bitmapImage12 = new BitmapImage();
                        img12.Width = bitmapImage12.DecodePixelWidth = 80;
                        bitmapImage12.UriSource = new Uri(img12.BaseUri, paths);
                        img12.Source = bitmapImage12;
                        decCounter = counter;
                    }
                    else
                    {
                        img12.Source = null;
                        decCounter--;
                        counter = decCounter + 1;
                    }
                    break;
            }

        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            metronome.Position = TimeSpan.Zero;
            metronome.Play();
            Processor();
        }
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            Counter("", 1);
        }
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
