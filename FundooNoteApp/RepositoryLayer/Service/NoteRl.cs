using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NoteRl : INoteRl
    {
        FundooContext fundooContext;
        public NoteRl(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        public NoteEntity CreateNewNote(NewNote newNote, long UserId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                noteEntity.Title = newNote.Title;
                noteEntity.Note = newNote.Note;
                DateTime createNoteDateTime = DateTime.Now;
                noteEntity.CreatedNoteTime = createNoteDateTime;
                noteEntity.ModifiedNoteTime = createNoteDateTime;
                noteEntity.UserId = UserId;
                fundooContext.NoteDetails.Add(noteEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                {
                    return noteEntity;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveNotes(RetriveNote retriveNote,long userId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == retriveNote.NoteID && x.UserId == userId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveAllNotes(long userId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.UserId == userId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int MoveToTrash(TrashNote deleteNote, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == deleteNote.NoteID && x.UserId == UserId).FirstOrDefault();
                if (result != null)
                {
                    result.IsTrash = !result.IsTrash;
                    DateTime createNoteDateTime = DateTime.Now;
                    result.ModifiedNoteTime = createNoteDateTime;
                    fundooContext.SaveChanges();
                    return Convert.ToInt16(true) + Convert.ToInt16(!result.IsTrash);
                }
                else
                {
                    return Convert.ToInt16(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
