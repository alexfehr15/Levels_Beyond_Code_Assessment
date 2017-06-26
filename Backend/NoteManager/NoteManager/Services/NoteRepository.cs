using NoteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteManager.Services
{
    /// <summary>
    /// Repository storing notes in current application domain cache.
    /// </summary>
    public class NoteRepository
    {
        // cache key
        private const string CACHE_KEY = "NoteStore";

        // static counter ensuring note ids are unique
        private static int s_idCounter = 1;

        /// <summary>
        /// Constructor.
        /// </summary>
        public NoteRepository()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Cache[CACHE_KEY] == null)
                {
                    // start without any notes
                    ctx.Cache[CACHE_KEY] = new Note[0];
                }
            }
        }

        /// <summary>
        /// Get all notes in the repository.
        /// </summary>
        /// <returns>All notes in the repository.</returns>
        public Note[] GetAllNotes()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                return (Note[])ctx.Cache[CACHE_KEY];
            }

            return new Note[0];
        }

        /// <summary>
        /// Get a specific note out of the respository.
        /// </summary>
        /// <param name="id">Note id.</param>
        /// <returns>Note with matching id if found, null otherwise.</returns>
        public Note GetNote(int id)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                Note[] notes = ctx.Cache[CACHE_KEY] as Note[];
                if (notes != null)
                {
                    foreach (Note Note in notes)
                    {
                        if (Note.Id == id)
                            return Note;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Get all notes with body containing query string.
        /// </summary>
        /// <param name="query">Query string.</param>
        /// <returns>All notes with body containing query string, empty otherwise.</returns>
        public Note[] GetNote(string query)
        {
            List<Note> NotesMatchingQuery = new List<Note>();

            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                Note[] notes = ctx.Cache[CACHE_KEY] as Note[];
                if (notes != null)
                {
                    foreach (Note Note in notes)
                    {
                        if (Note.Body.Contains(query))
                            NotesMatchingQuery.Add(Note);
                    }
                }
            }

            return (NotesMatchingQuery.Count > 0) ? NotesMatchingQuery.ToArray() : new Note[0];
        }

        /// <summary>
        /// Save a note to the repository.
        /// </summary>
        /// <param name="note">Note to save.</param>
        /// <returns>True if note was saved successfully, false otherwise.</returns>
        public bool SaveNote(Note note)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    // add the note to the cache
                    List<Note> currentData = ((Note[])ctx.Cache[CACHE_KEY]).ToList();
                    currentData.Add(note);
                    ctx.Cache[CACHE_KEY] = currentData.ToArray();

                    // adjust note id
                    note.Id = s_idCounter++;

                    // success
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Remove a note from the repository.
        /// </summary>
        /// <param name="id">Note id.</param>
        /// <param name="note">Note removed if successful, null otherwise.</param>
        /// <returns>True if remove is successful, false otherwise.</returns>
        public bool DeleteNote(int id, out Note note)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                Note[] notes = ctx.Cache[CACHE_KEY] as Note[];
                if (notes != null)
                {
                    List<Note> notesList = notes.ToList();
                    for (int i = 0; i < notesList.Count; ++i)
                    {
                        if (notesList[i].Id == id)
                        {
                            note = notesList[i];
                            notesList.RemoveAt(i);
                            ctx.Cache[CACHE_KEY] = notesList.ToArray();
                            return true;
                        }
                    }
                }
            }

            note = null;
            return false;
        }
    }
}