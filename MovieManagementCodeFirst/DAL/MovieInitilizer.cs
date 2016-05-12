using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieManagementCodeFirst.Models;

namespace MovieManagementCodeFirst.DAL
{
    public class MovieInitilizer : DropCreateDatabaseIfModelChanges<MovieDBContext>
    {
        protected override void Seed(MovieDBContext context)
        {
            List<TicketType> listTicketType = new List<TicketType>
            {
                new TicketType{Name = "Cao cấp", Seat = "A", PricePercent = 30 },
                new TicketType{Name = "Trung cấp", Seat = "B", PricePercent = 20 },
                new TicketType{Name = "Bình thường", Seat = "C", PricePercent = 10 },
            };

            List<FilmType> listFilmType = new List<FilmType>
            {
                new FilmType{Name = "Khoa học viễn tưởng" },
                new FilmType{Name = "Hành động" },
                new FilmType{Name = "Tình cảm" },
                new FilmType{Name = "Hài" },
                new FilmType{Name = "Tâm lý xã hội" },
                new FilmType{Name = "Võ thuật" },
                new FilmType{Name = "Chiến tranh" },
                new FilmType{Name = "Hình sự" },
                new FilmType{Name = "Tài liệu" },
                new FilmType{Name = "Hoạt hình" },
                new FilmType{Name = "Cổ trang" },
                new FilmType{Name = "Phiêu lưu" },
            };

            context.TicketTypes.AddRange(listTicketType);
            context.FilmTypes.AddRange(listFilmType);
            context.SaveChanges();
        }
    }
}