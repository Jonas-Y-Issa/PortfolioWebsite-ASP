using Microsoft.EntityFrameworkCore;
using ASPPortfolio.Data;

namespace ASPPortfolio.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ASPPortfolioContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ASPPortfolioContext>>()))
        {
            if (context == null || context.Project == null)
            {
                throw new ArgumentNullException("Null ASPPortfolioContext");
            }

            if (context.Project.Any())
            {
                return;   // DB has been seeded
            }

            context.Project.AddRange(
                new Project
                {
                    Preface = "This Wesbite:",
                    Title = "Portfolio Website Github",
                    ExtLink = "https://github.com/Jonas-Y-Issa/PortfolioWebsite",
                    Description = "Host: My Raspberry Pi 4 (Debian) Stack: Javascript/MariaDB/Django/Gunicorn/Nginx Why a Raspberry Pi? The idea was to be able to interact with every possible step of creating a website, from SSL creation, Port Forwarding, Reverse Proxies and the tools required to achieve these such as NGINX and Django. The choice to use Django of course is due to the use of Python but also stems from the scalability of hosting not just this static webpage, but to have a place to be able to reliably host additional web applications in the future. I've made this open source. If you would like to check out the code or use it as a template for your own, please feel free to head over to github.",
                },
                new Project
                {
                    Preface = "Find it Here:",
                    Title = "Ball Knight on Oculus",
                    ExtLink = "https://www.oculus.com/experiences/quest/3852290258211569/",
                    Description = "A VR game Developed in Unity. Use your knightley reflexes and magic sword art to fend off never ending and ever increasing numbers of enemy balls! These bouncy baddies will have you overwhelmed in no time if not nimble and alert. Imbue your sword with the souls of your enemies then point it to the sky and watch your foes disappear in a crack of thunder. Will you continue to hold the title of hero in this once peaceful town? Compete to get your score on top of the leaderboard!",
                },                
                new Project
                {
                    Preface = "Find it Here:",
                    Title = "4-Way-chess",
                    ExtLink = "https://github.com/Jonas-Y-Issa/4-Way-Chess",
                    Description = "A Work in Progress. My first ever C# project, long before I learnt about Git I was saving RaR and Zip files to keep version history. A first lesson in the fundamentals of classes, frameworks, networking. Originally built 9 years ago on the XNA/MonoGame framework in C# I am currently refactoring to update the framework from XNA to its renamed MonoGame and further more moving it away from its Visual Studio IDE and into a more hands on environment in VSCode. Being a 9 year old project it may be best to restart on a better framework, rather than refactoring it all, however it holds sentimental value. I've made it public on Git for those interested.",
                },
                new Project
                {
                    Preface = "Try Me Now ->",
                    Title = "Terminal Go",
                    ExtLink = "https://github.com/Jonas-Y-Issa/Terminal-Go",
                    Description = "A Project to try and take the Console/Terminal to the brink of what's possible. The App is based on the board game 'Go', and uses the Terminal as the GUI, to enter moves and display the board. This was a introductory project to C# that I wrote some 8 years ago.",
                },
                new Project
                {
                    Preface = "-Coming Soon-",
                    Title = "Prosthetic Hands",
                    ExtLink = "https://developerjonas.com",
                    Description = "Robotic Hands, especially those marketed as Prosthetics, are a marketing gimmick. Reviews from amputees on these over-engineered prosthetics show that we have not even come close to the usefulness and capabilities of even a hook hand. A ratio of a hooks simplicity to its usefulness should always be the benchmark of prosthetics. Something that costs not even a tenth of the price but a hundredth, and has a theoretical minimum amount of points of failure, as compared to a robotic hand where over engineering has created a point of failure at every inch. Most are designed to look post-human, robotic, and above all stronger and more resilient, however in reality will never stand up to the challenge given the intricacies of human hands and the tasks we demand of them. The prosthetic hand itself isn't even the greatest challenge, but the control mechanisms.",
                },
                new Project
                {
                    Preface = "Further Reading:",
                    Title = "Eisfeld Metal Lathe",
                    ExtLink = "http://www.lathes.co.uk/eisfeld/",
                    Description = "A Lathe may be considered the mother of machines, with a little finesse it lives quite close to the idea of RepRap. Unlike other machines a Lathe is quite capable of building another Lathe, or any other Machine given its focus on precision. When I bought it, it was unusable, rust had locked many of the moving pieces and the centers were out of alignment. The idea was to have to take the machine apart and bring new life into it, that way understanding where every bolt goes and why. With new life and some TLC, the lathe is now capable of machining steel alloys with ease and not just its intended for brass.",
                }
            );
            context.SaveChanges();
        }
    }
}