namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Footballers.DataProcessor.XmlHelper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            const string root = "Coaches";
            var sb = new StringBuilder();
            var coachesDto = XmlConverter.Deserializer<CoachImportModelDto>(xmlString, root);
            var coaches=new List<Coach>();

            foreach (var c in coachesDto)
            {
                if (!IsValid(c))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Coach coach = new Coach()
                {
                    Name=c.Name,
                    Nationality=c.Nationality,
                };

                foreach (var f in c.Footballers)
                {
                    if (!IsValid(f))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime contractStartDate;
                    var isContractStartDateValid = DateTime.TryParseExact(f.ContractStartDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out contractStartDate);
                    if (!isContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime contractEndDate;
                    var isContractEndDateValid = DateTime.TryParseExact(f.ContractEndDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out contractEndDate);
                    if (!isContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractStartDate > contractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name=f.Name,
                        ContractStartDate=contractStartDate,
                        ContractEndDate=contractEndDate,
                        BestSkillType=(BestSkillType)f.BestSkillType,
                        PositionType=(PositionType)f.PositionType
                    };
                    coach.Footballers.Add(footballer);
                }
                coaches.Add(coach);
                sb.AppendLine($"Successfully imported coach - {coach.Name} with {coach.Footballers.Count} footballers.");
            }
            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var teamsDto = JsonConvert.DeserializeObject<TeamImportModelDto[]>(jsonString);
            var teams = new List<Team>();


            foreach (var t in teamsDto)
            {
                if (!IsValid(t))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (t.Trophies < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Team team = new Team()
                {
                    Name = t.Name,
                    Nationality=t.Nationality,
                    Trophies=t.Trophies,
                };
                var footballersTeams = new HashSet<TeamFootballer>();
                foreach (var fId in t.Footballers.Distinct().ToArray())
                {
                    Footballer footballer = context.Footballers
                      .Find(fId);

                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var teamFootballer = new TeamFootballer()
                    {
                        Team = team,
                        Footballer = footballer
                    };
                    footballersTeams.Add(teamFootballer);
                }
                team.TeamsFootballers = footballersTeams;
                teams.Add(team);
                sb.AppendLine($"Successfully imported team - {team.Name} with {team.TeamsFootballers.Count()} footballers.");
            }
            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
