using Microsoft.AspNetCore.SignalR;
using TashanSofrasi.DataAccessLayer.Concrete;

namespace TashanSofrasiSignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        TashanSofrasiContext context = new TashanSofrasiContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
