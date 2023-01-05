using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MJ_Rent_Login.Models
{
    public class NotifyInfo
    {
        [Display(Name = "編號")]
        public int Id { get; set; }

        [Display(Name = "使用者編號")]
        public string UserId { get; set; } = "";

        // 通知內容
        [Display(Name = "通知內容")]
        public string InfoContext { get; set; } = string.Empty;

        // 是否已經通知
        [Display(Name = "是否已通知")]
        public Boolean HaveNotify { get; set; }
    }
}
