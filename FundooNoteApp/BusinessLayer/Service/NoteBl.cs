using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NoteBl : INoteBl
    {
        INoteRl iNoteRl;
        public NoteBl(INoteRl iNoteRl)
        {
            this.iNoteRl = iNoteRl;
        }
        public NoteEntity CreateNewNote(NewNote newNote, long UserId)
        {
            try
            {
                return iNoteRl.CreateNewNote(newNote, UserId);
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
                return iNoteRl.MoveToTrash(deleteNote, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveNotes(RetriveNote retriveNote, long noteId)
        {
            try
            {
                return iNoteRl.RetrieveNotes(retriveNote, noteId);
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
                return iNoteRl.RetrieveAllNotes(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
