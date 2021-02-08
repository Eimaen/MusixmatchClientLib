using MusixmatchClientLib.Auth;
using MusixmatchClientLib.Exploits;
using MusixmatchClientLib.Types;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace MusixmatchClientLib.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MusixmatchToken token = new MusixmatchToken("210123f3312aa5830ea3094a9ca2ae36ebf87840002377cca15cb3");
            MusixmatchClient client = new MusixmatchClient(token);
          
            #region User Score & Info

            // My country's weekly top
            var score = client.GetUserWeeklyTop("BY")[0];

            // Change color for the username to look cool
            ConsoleColor color;
          
            switch (score.RankName)
            {
                case "newbie":
                    color = ConsoleColor.Cyan;
                    break;
                case "insider":
                    color = ConsoleColor.Green;
                    break;
                case "master":
                    color = ConsoleColor.Red;
                    break;
                case "hero":
                    color = ConsoleColor.Magenta;
                    break;
                case "king":
                    color = ConsoleColor.Yellow;
                    break;
                default:
                    color = ConsoleColor.Gray;
                    break;
            }

            #region User Info

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("You are logged in as: ");
            Console.ForegroundColor = color;
            Console.WriteLine(score.UserName);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Ranking: ");
            Console.ForegroundColor = color;
            Console.WriteLine($"{score.Score}, {score.RankLevel}LVL ({score.RankName})");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Weekly points: ");
            Console.ForegroundColor = color;
            Console.WriteLine($"+{score.WeeklyScore}\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Counters: ");

            #region Counters

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsAiMoodAnalysisV3Value: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsAiMoodAnalysisV3Value}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsAiPhrasesNotRelatedNo: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsAiPhrasesNotRelatedNo}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsAiPhrasesNotRelatedSkip: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsAiPhrasesNotRelatedSkip}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsAiPhrasesNotRelatedYes: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsAiPhrasesNotRelatedYes}");
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsAiUgcLanguage: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsAiUgcLanguage}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsChanged: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsChanged}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsFavouriteAdded: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsFavouriteAdded}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsImplicitlyOk: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsImplicitlyOk}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsKo: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsKo}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsMissing: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsMissing}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsMusicId: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsMusicId}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsOk: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsOk}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsRankingChange: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsRankingChange}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsReportCompletelyWrong: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsReportCompletelyWrong}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsReportContainMistakes: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsReportContainMistakes}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsReportIncompleteLyrics: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsReportIncompleteLyrics}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsRichsyncAdded: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsRichsyncAdded}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  LyricsSubtitleAdded: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.LyricsSubtitleAdded}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  TrackCompleteMetadata: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.TrackCompleteMetadata}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  TrackInfluencerBonusModeratorVote: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.TrackInfluencerBonusModeratorVote}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  TrackStructure: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.TrackStructure}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  TrackTranslation: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.TrackTranslation}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  TranslationOk: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.TranslationOk}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  VoteBonuses: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.VoteBonuses}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  VoteMaluses: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{score.Counters.VoteMaluses}");

            #endregion

            #endregion

            #endregion
        }
    }
}
