namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.DataProcessor.XmlHelper;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            const string root = "Coaches";
            var coaches = context.Coaches
                .ToArray()
                .Where(c => c.Footballers.Any())
                .Select(c => new CoachExportModelDto()
                {
                    CoachName = c.Name,
                    FootballersCount = c.Footballers.Count,
                    Footballers=c.Footballers
                    .Select(f => new FootballersExportModelDto()
                    {
                        Name = f.Name,
                        Position=f.PositionType.ToString(),
                    })
                    .OrderBy(c => c.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.Footballers.Length)
                .ThenBy(c => c.CoachName)
                .ToArray();

            var xmlResult = XmlConverter.Serialize<CoachExportModelDto>(coaches, root);
            return xmlResult;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
              .ToArray()
              .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
              .Select(t => new
              {
                  Name = t.Name,
                  Footballers = t.TeamsFootballers
                  .Where(tf => tf.Footballer.ContractStartDate >= date)
                  .Select(tf => tf.Footballer)
                  .OrderByDescending(f => f.ContractEndDate)
                  .ThenBy(f => f.Name)
                  .Select(f =>
                  new
                  {
                      FootballerName = f.Name,
                      ContractStartDate = f.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                      ContractEndDate = f.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                      BestSkillType = f.BestSkillType.ToString(),
                      PositionType = f.PositionType.ToString(),
                  })
                  .ToArray()
              })
              .OrderByDescending(x => x.Footballers.Count())
              .ThenBy(t => t.Name)
              .Take(5)
              .ToArray();
            var jsonResult = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return jsonResult;
        }
    }
}
