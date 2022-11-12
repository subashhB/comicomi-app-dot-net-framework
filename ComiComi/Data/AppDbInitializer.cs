using ComiComi.Data.Enums;
using ComiComi.Data.Static;
using ComiComi.Models;
using Microsoft.AspNetCore.Identity;

namespace ComiComi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            ArtistName ="Eiichiro Oda",
                            Bio ="Creator of One Piece"
                        },

                        new Artist()
                        {
                            ArtistName="Steve Ditko",
                            Bio="Artist of Spider-Man"
                        },
                        new Artist()
                        {
                            ArtistName ="Masashi Kishimoto",
                            Bio ="Creator of Naruto"
                        },
                        new Artist()
                        {
                            ArtistName ="Vofan",
                            Bio ="Artist from Taiwan, Best known as Artist of Monogatari Series"
                        },
                        new Artist()
                        {
                            ArtistName ="Takashi Takeuchi",
                            Bio ="One of the Major Artists of Type-Moon"
                        }
                        

                    });
                    context.SaveChanges();

                }
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>(){
                        new Author()
                        {
                            AuthorName = "Eiichiro Oda",
                            Bio = "Creator of One Piece"
                        },
                        new Author()
                        {
                            AuthorName = "Stan Lee",
                            Bio = "Founder of Marvel Comics"
                        },
                        new Author()
                        {
                            AuthorName = "Masashi Kishimoto",
                            Bio = "Creator of Naruto"
                        },
                        new Author()
                        {
                            AuthorName = "NISHIOISHIN",
                            Bio = "Author of Monogatari Series"
                        },
                        new Author()
                        {
                            AuthorName = "Kinoki Nasu",
                            Bio = "Main Author and Co-Founder of Type-Moon"
                        }
                    });
                    context.SaveChanges();

                }
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            PublisherName ="Shounen Jump" 
                        },

                        new Publisher()
                        {
                            PublisherName="Marvel Comics"
                        },
                        new Publisher()
                        {
                            PublisherName ="Kodansha"
                        },                        
                        new Publisher()
                        {
                            PublisherName ="Type-Moon"
                        }
                    });
                    context.SaveChanges();

                }
                if (!context.Comics.Any())
                {
                    context.Comics.AddRange(new List<Comic>()
                    {
                        new Comic()
                        {
                            Title="One Piece",
                            CoverPhotoURL="https://m.media-amazon.com/images/I/518KKkmd1fL._AC_SY780_.jpg",
                            Description="The series focuses on Monkey D. Luffy, a young man made of rubber, who, inspired by his childhood idol, the powerful pirate Red-Haired Shanks, sets off on a journey from the East Blue Sea to find the mythical treasure, the One Piece, and proclaim himself the King of the Pirates.",
                            Price=800,
                            UploadDate=DateTime.Now,
                            Genre= Genre.Adventure,
                            Serializaton= Serialization.Weekly,
                            Day= Day.SAT,
                            Status = Status.Ongoing,
                            Volume = 103,
                            AuthorId=1,
                            ArtistId=1,
                            PublisherId=1,
                        },
                        new Comic()
                        {
                            Title="Spider-Man",
                            CoverPhotoURL="https://i.pinimg.com/originals/ea/39/35/ea3935169ced0756449bac6b4cfe9efb.jpg",
                            Description="American teenager Peter Parker, a poor sickly orphan, is bitten by a radioactive spider. As a result of the bite, he gains superhuman strength, speed, and agility, along with the ability to cling to walls, turning him into Spider-Man.",
                            Price=250,
                            UploadDate=DateTime.Now,
                            Genre= Genre.SciFi,
                            Serializaton= Serialization.Weekly,
                            Day= Day.SUN,
                            Status = Status.Ongoing,
                            Volume = 160,
                            AuthorId=2,
                            ArtistId=2,
                            PublisherId=2,
                        },
                        new Comic()
                        {
                            Title="Naruto",
                            CoverPhotoURL="https://pm1.narvii.com/6106/fd2d7db8b7983348bcbeba05fe52a5d308e8fb2b_hq.jpg",
                            Description="It tells the story of Naruto Uzumaki, a young ninja who seeks recognition from his peers and dreams of becoming the Hokage, the leader of his village. The story is told in two parts – the first set in Naruto's pre-teen years, and the second in his teens.",
                            Price=720,
                            UploadDate=DateTime.Now,
                            Genre= Genre.Fantasy,
                            Serializaton= Serialization.Weekly,
                            Day= Day.SAT,
                            Status = Status.Completed,
                            Volume = 72,
                            AuthorId=3,
                            ArtistId=3,
                            PublisherId=1,
                        },
                        new Comic()
                        {
                            Title="Monogatari",
                            CoverPhotoURL="https://m.media-amazon.com/images/I/417sjvU-HoL._AC_SY780_.jpg",
                            Description="The plot centers on Koyomi Araragi, a third-year high school student who survives a vampire attack and finds himself helping people involved with a variety of apparitions, deities, ghosts, beasts, spirits, and other supernatural phenomena, which often serve as proxies for their emotional and mental issues.",
                            Price=540,
                            UploadDate=DateTime.Now,
                            Genre= Genre.Supernatural,
                            Serializaton= Serialization.Monthly,
                            Day= Day.SAT,
                            Status = Status.Ongoing,
                            Volume = 28,
                            AuthorId=4,
                            ArtistId=4,
                            PublisherId=3,
                        },
                        new Comic()
                        {
                            Title="Kara no Kyoukai: The Garder of Sinners",
                            CoverPhotoURL="https://static.wikia.nocookie.net/sonako/images/d/d0/Vol1-cover.jpg/revision/latest?cb=20151231160738",
                            Description="Set in Japan predominantly during the late 1990s, The Garden of Sinners follows the story of Shiki Ryougi, a teenage girl raised as a demon hunter who acquired the \"Mystic Eyes of Death Perception\" after surviving a fatal accident.",
                            Price=430,
                            UploadDate=DateTime.Now,
                            Genre= Genre.Dark,
                            Serializaton= Serialization.Monthly,
                            Day= Day.SAT,
                            Status = Status.Completed,
                            Volume = 7,
                            AuthorId=5,
                            ArtistId=5,
                            PublisherId=4,
                        }


                    });
                    context.SaveChanges();
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if(!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@comicomi.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "ComiAdmin@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@comicomi.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "ComiAppUser@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
