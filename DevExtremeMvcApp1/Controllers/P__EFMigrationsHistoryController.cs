using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DevExtremeMvcApp1.Models.FuhrparkContext;

namespace DevExtremeMvcApp1.Controllers
{
    // If you need to use Data Annotation attributes, attach them to this view model instead of an XPO data model.
    public class P__EFMigrationsHistoryViewModel {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }

    [Route("api/P__EFMigrationsHistory/{action}", Name = "P__EFMigrationsHistoryApi")]
    public class P__EFMigrationsHistoryController : ApiController
    {
        private UnitOfWork _uow = new UnitOfWork(ConnectionHelper.GetDataLayer(AutoCreateOption.SchemaAlreadyExists));

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions) {
            var p__efmigrationshistory = _uow.Query<P__EFMigrationsHistory>().Select(i => new P__EFMigrationsHistoryViewModel {
                MigrationId = i.MigrationId,
                ProductVersion = i.ProductVersion
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "MigrationId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Request.CreateResponse(await DataSourceLoader.LoadAsync(p__efmigrationshistory, loadOptions));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form) {
            var model = new P__EFMigrationsHistory(_uow);
            var viewModel = new P__EFMigrationsHistoryViewModel();
            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));

            PopulateViewModel(viewModel, values);

            Validate(viewModel);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            CopyToModel(viewModel, model);

            await _uow.CommitChangesAsync();

            return Request.CreateResponse(HttpStatusCode.Created, model.MigrationId);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form) {
            var key = Convert.ToString(form.Get("key"));
            var model = _uow.GetObjectByKey<P__EFMigrationsHistory>(key, true);
            if(model == null)
                return Request.CreateResponse(HttpStatusCode.Conflict, "Object not found");

            var viewModel = new P__EFMigrationsHistoryViewModel {
                MigrationId = model.MigrationId,
                ProductVersion = model.ProductVersion
            };

            var values = JsonConvert.DeserializeObject<IDictionary>(form.Get("values"));
            PopulateViewModel(viewModel, values);

            Validate(viewModel);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, GetFullErrorMessage(ModelState));

            CopyToModel(viewModel, model);

            await _uow.CommitChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task Delete(FormDataCollection form) {
            var key = Convert.ToString(form.Get("key"));
            var model = _uow.GetObjectByKey<P__EFMigrationsHistory>(key, true);

            _uow.Delete(model);
            await _uow.CommitChangesAsync();
        }


        const string MIGRATION_ID = nameof(P__EFMigrationsHistory.MigrationId);
        const string PRODUCT_VERSION = nameof(P__EFMigrationsHistory.ProductVersion);

        private void PopulateViewModel(P__EFMigrationsHistoryViewModel viewModel, IDictionary values) {
            if(values.Contains(MIGRATION_ID)) {
                viewModel.MigrationId = Convert.ToString(values[MIGRATION_ID]);
            }
            if(values.Contains(PRODUCT_VERSION)) {
                viewModel.ProductVersion = Convert.ToString(values[PRODUCT_VERSION]);
            }
        }

        private void CopyToModel(P__EFMigrationsHistoryViewModel viewModel, P__EFMigrationsHistory model) {
            model.MigrationId = viewModel.MigrationId;
            model.ProductVersion = viewModel.ProductVersion;
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
