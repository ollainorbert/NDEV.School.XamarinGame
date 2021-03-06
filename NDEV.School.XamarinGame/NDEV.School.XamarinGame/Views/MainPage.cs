﻿using NDEV.School.XamarinGame.Controllers;
using NDEV.School.XamarinGame.Views;
using System;

using Xamarin.Forms;

namespace NDEV.School.XamarinGame
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            this._mainPageController = new MainPageController(this);

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    throw new Exception("This app doesn't support IOS!");
                default:
                    this._settingsPage = new SettingsPage(this._mainPageController);
                    this._gamePlayPage = new GamePlayPage(this._mainPageController);
                    this._sgPage = new SGPage();
                    this._aboutPage = new AboutPage();
                    break;
            }

            this.Children.Add(this._settingsPage);
            this.Children.Add(this._gamePlayPage);
            this.Children.Add(this._sgPage);
            this.Children.Add(this._aboutPage);
            
            this.Title = this.CurrentPage.Title;
        }

        private MainPageController _mainPageController;
        private Page _settingsPage;
        private GamePlayPage _gamePlayPage;
        private Page _sgPage;
        private Page _aboutPage;

        public void SwitchToGamePlay(GamePlayModeEnum gamePlayMode)
        {
            this._gamePlayPage.SetGameSettings(gamePlayMode);
            this._switchWithAddAndRemove(this._gamePlayPage);
        }

        public void SwitchToSettingsPage()
        {
            this._switchWithAddAndRemove(this._settingsPage);
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            this.Title = this.CurrentPage?.Title ?? string.Empty;
        }

        private void _switchPage(Page switchFrom, Page switchTo)
        {
            switchFrom.IsVisible = false;
            switchTo.IsVisible = true;
            this.CurrentPage = switchTo;
        }

        private void _switchWithAddAndRemove(Page switchTo)
        {
            this.Children.Insert(1, switchTo);
            this.Children.RemoveAt(0);
            this.CurrentPage = switchTo;
        }
    }
}
