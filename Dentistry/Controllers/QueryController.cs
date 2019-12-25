using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentistry.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Dentistry.Controllers
{
    public class QueryController : Controller
    {
        private readonly string _connectionString;

        public QueryController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(QueryViewModel model)
        {
            try 
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = model.Query;

                var reader = command.ExecuteReader();

                var a = reader.GetColumnSchema();
                var table = new StringBuilder()
                    .Append("<table>")
                    .Append("<thead>")
                    .Append("<tr>");

                table.Append(a.Select(x => $"<th>{x.ColumnName}</th>").Aggregate((first, second) => first + second));

                table
                    .Append("</tr>")
                    .Append("</thead>")
                    .Append("<tbody>");

                while (reader.Read())
                {
                    table.Append("<tr>");

                    for (int i = 0; i < reader.GetColumnSchema().Count; i++)
                    {
                        table.Append($"<td>{reader.GetValue(i).ToString()}</td>");
                    }

                    table.Append("</tr>");
                }

                table
                    .Append("</tbody>")
                    .Append("</table>");

                model.Table = table.ToString();
                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }
        }
    }
}