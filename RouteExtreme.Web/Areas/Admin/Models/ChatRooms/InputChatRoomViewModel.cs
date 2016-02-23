namespace RouteExtreme.Web.Areas.Admin.Models.ChatRooms
{
    using System.Web.Mvc;

    public class InputChatRoomViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}