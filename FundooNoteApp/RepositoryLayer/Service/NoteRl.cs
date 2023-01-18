using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public bool UpdateNote(UpdateNote updateNote, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == updateNote.NoteID && x.UserId == UserId).FirstOrDefault();
                if(result != null)
                {
                    result.Title = updateNote.Title;
                    result.Note = updateNote.Note;
                    DateTime createNoteDateTime = DateTime.Now;
                    result.ModifiedNoteTime = createNoteDateTime;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveNotes(RetriveNote retriveNote,long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == retriveNote.NoteID && x.UserId == UserId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<NoteEntity> RetrieveAllNotes(long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.UserId == UserId);
                return result;
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
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == trash.NoteID && x.UserId == UserId).FirstOrDefault();
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
        public bool DeleteNote(PinTrashArchieve delete, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == delete.NoteID && x.UserId == UserId && x.IsTrash == true).FirstOrDefault();
                if (result != null)
                {
                    fundooContext.NoteDetails.Remove(result);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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
                var result = fundooContext.NoteDetails.Where(x =>  x.UserId == UserId && x.IsTrash == true);
                if (result != null)
                {
                    foreach(var data in result)
                    {
                        fundooContext.NoteDetails.Remove(data);
                    }
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
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
                var result = fundooContext.NoteDetails.Where(x => x.UserId == UserId && x.IsTrash == true).FirstOrDefault();
                if (result != null)
                {
                    TimeSpan timeSpan = result.ModifiedNoteTime - DateTime.UtcNow;
                    if(timeSpan.Days == 7)
                    {
                        fundooContext.NoteDetails.Remove(result);
                        fundooContext.SaveChanges();
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
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
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == pin.NoteID && x.UserId == UserId).FirstOrDefault();
                if (result != null)
                {
                    result.IsPin = !result.IsPin;
                    result.ModifiedNoteTime = DateTime.Now;
                    fundooContext.SaveChanges();
                    return Convert.ToInt16(true) + Convert.ToInt16(!result.IsPin);
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

        public int ArchieveNote(PinTrashArchieve archieve, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == archieve.NoteID && x.UserId == UserId).FirstOrDefault();
                if (result != null)
                {
                    result.IsArchive = !result.IsArchive;
                    result.ModifiedNoteTime = DateTime.Now;
                    fundooContext.SaveChanges();
                    return Convert.ToInt16(true) + Convert.ToInt16(!result.IsArchive);
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
        
        public bool NoteColor(NoteColor noteColor, long UserId)
        {
            try
            {
                var result = fundooContext.NoteDetails.Where(x => x.NoteID == noteColor.NoteID && x.UserId == UserId).FirstOrDefault();
                if(result != null)
                {
                    result.Color = noteColor.Color;
                    result.ModifiedNoteTime = DateTime.Now;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
