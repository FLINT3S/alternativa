using RAGE;
using RAGE.Game;
using RAGE.Ui;

namespace testClientResource
{
    public class Main : Events.Script
    {
        private static HtmlWindow browser;

        public Main()
        {
            Events.OnPlayerReady += OnPlayerReady;
            
            Events.Add("CEF:CLIENT:Test", OnTest);
            
            Input.Bind(VirtualKeys.F2, true, OnToggleBrowser);
        }

        private void OnTest(object[] args)
        {
            Chat.Output("Альтернатива - лучший сервер");
            Chat.Output(args.ToString());
        }

        private void OnPlayerReady()
        {
            Chat.Output("testClientResource123");
        }

        private void OnCreateBrowser()
        {
            browser = new HtmlWindow("package://web/index.html");
            browser.Active = true;
            Cursor.ShowCursor(true, true);
        }
        
        private void OnDestroyBrowser()
        {
            browser.Active = false;
            browser.Destroy();
            Cursor.ShowCursor(false, false);
        }

        private void OnToggleBrowser()
        {
            if (browser == null || !browser.Active)
            {
                OnCreateBrowser();
            }
            else
            {
                OnDestroyBrowser();
            }
        }
    }
}