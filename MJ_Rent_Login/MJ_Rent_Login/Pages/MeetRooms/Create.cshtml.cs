using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MJ_Rent_Login.Data;
using MJ_Rent_Login.Models;

namespace MJ_Rent_Login.Pages.MeetRooms
{
    public class CreateModel : PageModel
    {
        private readonly MJ_Rent_Login.Data.ApplicationDbContext _context;
        public SelectList? Ids { get; set; } //屬性


        public CreateModel(MJ_Rent_Login.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // 第一步：從 MeetRoom 中，select 所有會議室的 Id
            IQueryable<int> genreQuery = from m in _context.MeetRoom
                                            orderby m.Id 
                                            select m.Id;

            // await + ToListAsync => 非同步等待模式
            Ids = new SelectList(await genreQuery.Distinct().ToListAsync());

            // 第二步：將 Id 列表，轉成 <select> 中的選項

            return Page();  //產生的是Create.cshtml的頁面
        }

        [BindProperty]
        public MeetRoom MeetRoom { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MeetRoom.Add(MeetRoom);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
