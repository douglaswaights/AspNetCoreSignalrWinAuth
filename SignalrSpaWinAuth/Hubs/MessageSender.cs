using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalrSpaWinAuth.Hubs
{
  public class MessageSender
  {
    private IHubContext<MyHub> _hubContext;
    private Timer _timer;
    private const long DefaultPollingInterval = 10 * 1000;
    public MessageSender(IHubContext<MyHub> hubContext)
    {
      _hubContext = hubContext;
      _timer = new Timer();
      _timer.Elapsed += SendMessage;
      _timer.Interval = DefaultPollingInterval;

    }

    private void SendMessage(object sender, ElapsedEventArgs elapsedEventArgs)
    {
      _hubContext.Clients.All.InvokeAsync("send", "hello");
    }

    public void StartMessaging()
    {
      _timer.Start();
    }
  }
}
