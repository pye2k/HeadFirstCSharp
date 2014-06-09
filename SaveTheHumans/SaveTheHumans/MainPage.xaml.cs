using SaveTheHumans.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SaveTheHumans
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        Random random = new Random();
        DispatcherTimer enemyTimer = new DispatcherTimer(); // timer to control when new enemies appear
        DispatcherTimer targetTimer = new DispatcherTimer(); // timer to check whether we've reached the target
        bool humanCaptured = false; // is the human captured by the mouse?

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            // draw a new enemy every 2 seconds
            enemyTimer.Tick += enemyTimer_Tick;
            enemyTimer.Interval = TimeSpan.FromSeconds(2);

            // check the state of the game every 100ms
            targetTimer.Tick += targetTimer_Tick;
            targetTimer.Interval = TimeSpan.FromSeconds(.1);
        }

        /// <summary>
        /// Increment the progressBar. When progressBar reaches the end, end the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void targetTimer_Tick(object sender, object e)
        {
            progressBar.Value += 1;
            if (progressBar.Value >= progressBar.Maximum)
            {
                EndTheGame();
            }
        }

        /// <summary>
        /// Cleanup when ending the game.
        /// </summary>
        private void EndTheGame()
        {
            if (!playArea.Children.Contains(gameOverText))
            {
                enemyTimer.Stop();
                targetTimer.Stop();
                humanCaptured = false;
                startButton.Visibility = Visibility.Visible;

                // place the gameOverText in the middle of the playArea
                // however, had to hack this a little because ActualWidth/ActualHeight aren't populated yet,
                // see http://stackoverflow.com/questions/13835690/how-to-calculate-actualwidth-actualheight-before-window-showing
                gameOverText.Visibility = Visibility.Visible;
                gameOverText.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                //Debug.WriteLine("{0}, {1}", gameOverText.DesiredSize.Width, gameOverText.DesiredSize.Height);
                Canvas.SetLeft(gameOverText, (playArea.ActualWidth - gameOverText.ActualWidth) / 2);
                Canvas.SetTop(gameOverText, (playArea.ActualHeight - gameOverText.ActualHeight) / 2);
                playArea.Children.Add(gameOverText);
            }
        }

        /// <summary>
        /// Allow addition of enemies at specific intervals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void enemyTimer_Tick(object sender, object e)
        {
            AddEnemy();
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        /// <summary>
        /// When the startButton is clicked, start the game!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Reset the state when starting a new game.
        /// </summary>
        private void StartGame()
        {
            randomizePlacement(target);
            target.Visibility = Visibility.Visible;
            randomizePlacement(human);
            human.Visibility = Visibility.Visible;
            human.IsHitTestVisible = true;
            humanCaptured = false;
            progressBar.Value = 0;
            startButton.Visibility = Visibility.Collapsed;
            playArea.Children.Clear();
            playArea.Children.Add(human);
            playArea.Children.Add(target);
            enemyTimer.Start();
            targetTimer.Start();
        }

        /// <summary>
        /// Add a new enemy within the bounds of the playArea
        /// </summary>
        private void AddEnemy()
        {
            ContentControl enemy = new ContentControl();
            enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
            AnimateEnemy(enemy, 0, playArea.ActualWidth - 100, "(Canvas.Left)");
            AnimateEnemy(enemy, random.Next((int)playArea.ActualHeight - 100), random.Next((int)playArea.ActualHeight - 100), "(Canvas.Top)");
            playArea.Children.Add(enemy);

            enemy.PointerEntered += enemy_PointerEntered;
        }

        void enemy_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (humanCaptured)
            {
                EndTheGame();
            }
        }

        /// <summary>
        /// Set up animation for an enemy.
        /// </summary>
        /// <param name="enemy">The enemy.</param>
        /// <param name="from">Minimum value.</param>
        /// <param name="to">Maximum value.</param>
        /// <param name="propertyToAnimate">Either "(Canvas.Left)" or "(Canvas.Top)".</param>
        private void AnimateEnemy(ContentControl enemy, double from, double to, string propertyToAnimate)
        {
            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6)))
            };
            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        /// <summary>
        /// When the mouse clicks on the human, capture it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void human_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (enemyTimer.IsEnabled)
            {
                humanCaptured = true;
                human.IsHitTestVisible = false;
            }
        }

        /// <summary>
        /// Collision detection for a human entering the target. When that happens, reset the progressBar and randomize human/target locations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void target_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (targetTimer.IsEnabled && humanCaptured)
            {
                progressBar.Value = 0;
                randomizePlacement(target);
                randomizePlacement(human);
                humanCaptured = false;
                human.IsHitTestVisible = true;
            }
        }

        /// <summary>
        /// Randomly place a UIElement somewhere in the playArea
        /// </summary>
        /// <param name="element"></param>
        private void randomizePlacement(UIElement element)
        {
            Canvas.SetLeft(element, random.Next(100, (int)playArea.ActualWidth - 100));
            Canvas.SetTop(element, random.Next(100, (int)playArea.ActualHeight - 100));
        }

        /// <summary>
        /// Move the human with the mouse pointer movement (e.g. dragging).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playArea_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (humanCaptured)
            {
                Point pointerPosition = e.GetCurrentPoint(null).Position;
                Point relativePosition = grid.TransformToVisual(playArea).TransformPoint(pointerPosition);
                if ((Math.Abs(relativePosition.X - Canvas.GetLeft(human)) > human.ActualWidth * 3)
                    || Math.Abs(relativePosition.Y - Canvas.GetTop(human)) > human.ActualHeight * 3)
                {
                    humanCaptured = false;
                    human.IsHitTestVisible = true;
                }
                else
                {
                    Canvas.SetLeft(human, relativePosition.X - human.ActualWidth / 2);
                    Canvas.SetTop(human, relativePosition.Y - human.ActualHeight / 2);
                }
            }
        }

        /// <summary>
        /// Dragging the human off the playArea ends the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playArea_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (humanCaptured)
            {
                EndTheGame();
            }
        }
    }
}
