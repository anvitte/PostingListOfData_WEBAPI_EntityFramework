using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MultiModel_API.Data;
using MultiModel_API.Models;
using Newtonsoft.Json;

namespace MultiModel_API.Controllers
{
    public class QuestionModelsController : ApiController
    {
        private MultiModel_APIContext db = new MultiModel_APIContext();

        // GET: api/QuestionModels
        [HttpGet]
        public IQueryable<QuestionModel> GetQuestionModels()
        {
            return db.QuestionModels;
        }

        // GET: api/QuestionModels/5
        [ResponseType(typeof(QuestionModel))]
        public async Task<IHttpActionResult> GetQuestionModel(int id)
        {
            QuestionModel questionModel = await db.QuestionModels.FindAsync(id);
            if (questionModel == null)
            {
                return NotFound();
            }

            return Ok(questionModel);
        }

        // PUT: api/QuestionModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuestionModel(int id, QuestionModel questionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionModel.Id)
            {
                return BadRequest();
            }

            db.Entry(questionModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }



        private async Task<QuestionModel> PostQuestionModel(QuestionModel questionModel)
        {

            db.QuestionModels.Add(questionModel);
            await db.SaveChangesAsync();

            return new QuestionModel { Id = questionModel.Id, Answer = questionModel.Answer, QuestionDescription = questionModel.QuestionDescription };
        }


        // POST: api/QuestionModels
        [HttpPost]
        public async Task<IHttpActionResult> PostQuestionJson(List<QuestionModel> lstModel)
        {
            List<QuestionModel> lstQuestionPosted = new List<QuestionModel>();
            foreach (var item in lstModel)
            {
                lstQuestionPosted.Add(await PostQuestionModel(item));
            }
            return Json(JsonConvert.SerializeObject(lstQuestionPosted));
        }

        // DELETE: api/QuestionModels/5
        [ResponseType(typeof(QuestionModel))]
        public async Task<IHttpActionResult> DeleteQuestionModel(int id)
        {
            QuestionModel questionModel = await db.QuestionModels.FindAsync(id);
            if (questionModel == null)
            {
                return NotFound();
            }

            db.QuestionModels.Remove(questionModel);
            await db.SaveChangesAsync();

            return Ok(questionModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionModelExists(int id)
        {
            return db.QuestionModels.Count(e => e.Id == id) > 0;
        }
    }
}