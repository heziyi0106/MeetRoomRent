using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.NotifyInfos
{
    public class DetailsModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;

        public DetailsModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public NotifyInfo NotifyInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NotifyInfo == null)
            {
                return NotFound();
            }

            var notifyinfo = await _context.NotifyInfo.FirstOrDefaultAsync(m => m.Id == id);
            if (notifyinfo == null)
            {
                return NotFound();
            }
            else 
            {
                NotifyInfo = notifyinfo;
            }
            return Page();
        }
    }
}
