using NoteManager.Models;
using NoteManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoteManager.Controllers
{
    /// <summary>
    /// Notes controller.
    /// </summary>
    public class NotesController : ApiController
    {
        // repository used to store notes
        private NoteRepository NoteRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        public NotesController()
        {
            // create fresh repository
            this.NoteRepository = new NoteRepository();
        }

        /// <summary>
        /// Get a all notes.
        /// </summary>
        /// <returns>All notes in the repository.</returns>
        public Note[] Get()
        {
            return NoteRepository.GetAllNotes();
        }

        /// <summary>
        /// Get a specific note.
        /// </summary>
        /// <param name="id">Note id.</param>
        /// <returns>Note if present, null otherwise.</returns>
        public Note Get(int id)
        {
            return NoteRepository.GetNote(id);
        }

        /// <summary>
        /// Get all notes with a body containing supplied query string.
        /// </summary>
        /// <param name="query">Query to search for.</param>
        /// <returns>All notes with a body containing the supplied query string.</returns>
        public Note[] Get(string query)
        {
            return NoteRepository.GetNote(query);
        }

        /// <summary>
        /// Save a note to the repository.
        /// </summary>
        /// <param name="Note">Note to save.</param>
        /// <returns>Http response message.</returns>
        public HttpResponseMessage Post(Note Note)
        {
            // save the note to the repository
            this.NoteRepository.SaveNote(Note);

            // create http response message containing created note
            var response = Request.CreateResponse<Note>(System.Net.HttpStatusCode.Created, Note);

            return response;
        }

        /// <summary>
        /// Remove a specific note from the repository.
        /// </summary>
        /// <param name="id">Note id.</param>
        /// <returns>Http response message.</returns>
        public HttpResponseMessage Delete(int id)
        {
            // attempt to remove the note from the repository
            Note Note;
            bool success = this.NoteRepository.DeleteNote(id, out Note);

            HttpResponseMessage response;
            if (success)
                response = Request.CreateResponse<Note>(System.Net.HttpStatusCode.OK, Note);
            else
                response = Request.CreateResponse<Note>(System.Net.HttpStatusCode.NotFound, Note);

            return response;
        }
    }
    }
