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

        public bool UpdateNote(UpdateNote updateNote, long UserId)
        {
            try
            {
                return iNoteRl.UpdateNote(updateNote, UserId);
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

        public int MoveToTrash(PinTrashArchieve trash, long UserId)
        {
            try
            {
                return iNoteRl.MoveToTrash(trash, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNote(PinTrashArchieve delete, long UserId)
        {
            try
            {
                return iNoteRl.DeleteNote(delete, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAllTrashNote(long UserId)
        {
            try
            {
                return iNoteRl.DeleteAllTrashNote(UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete30DaysTrash(long UserId)
        {
            try
            {
                return iNoteRl.Delete30DaysTrash(UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int PinNote(PinTrashArchieve pin, long UserId)
        {
            try
            {
                return iNoteRl.PinNote(pin, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int ArchieveNote(PinTrashArchieve archieve, long UserId)
        {
            try
            {
                return iNoteRl.ArchieveNote(archieve, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool NoteColor(NoteColor noteColor, long UserId)
        {
            try
            {
                return iNoteRl.NoteColor(noteColor, UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
