using System;
using TestNoteWall.Data;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Array.Tests
{
    [TestFixture]
    public class NoteWallTest
    {
        private Mock<INoteContext> _mockContext;
        private NoteService _noteService;

        [SetUp]
        public void SetupBeforeEachTest()
        {
            _mockContext = new Mock<INoteContext>();
            _noteService = new NoteService(_mockContext.Object);
        }

        [Test]
        public void AddNote()
        {
            // Arrange
            var note = new Note();
            ArrangeContext(note);

            // Act
            var result = _noteService.AddNote(note);

            // Assert
            _mockContext.Verify(m => m.Add(It.Is<Note>(n => n == note)));
            VerifySaveChangesWithReturnNotes();
            AssertResult(note, result);
        }

        [Test]
        public void DeleteNote()
        {
            // Arrange
            var note = new Note("asd", "asd");
            ArrangeContext(note);

            // Act
            var result = _noteService.DeleteNote(note);

            // Assert
            _mockContext.Verify(m => m.Remove<Note>(It.Is<Note>(n => n == note)));
            VerifySaveChangesWithReturnNotes();
            AssertResult(note, result);
        }

        [Test]
        public void UpdateNote()
        {
            // Arrange
            var note = new Note("asd","asd");
            ArrangeContext(note);

            // Act
            var result = _noteService.UpdateNote(note);

            // Assert
            _mockContext.Verify(m => m.Update<Note>(It.Is<Note>(n => n == note)));
            VerifySaveChangesWithReturnNotes();
            AssertResult(note, result);
        }

        private void VerifySaveChangesWithReturnNotes()
        {
            _mockContext.Verify(m => m.GetNoteAsNoTracking());
            _mockContext.Verify(m => m.SaveChanges());
        }

        private void ArrangeContext(Note note)
        {
            _mockContext.Setup(m => m.GetNoteAsNoTracking()).Returns(new[] { note });
        }

        private static void AssertResult(Note note, IEnumerable<Note> result)
        {
            Assert.That(result.Contains(note));
            Assert.That(result != null);
        }
    }
}
