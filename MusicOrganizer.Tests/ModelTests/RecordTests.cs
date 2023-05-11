using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {
    public void Dispose()
    {
      Record.ClearAll();
    }

    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record newRecord = new Record("test record");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      //Arrange
      string title = "Test Record";
      Record newRecord = new Record(title);

      //Act
      string result = newRecord.Title;

      //Assert
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void GetId_ReturnsRecordId_Int()
    {
      //Arrange
      string title = "Test Record";
      Record newRecord = new Record(title);

      //Act
      int result = newRecord.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllRecordObjects_RecordList()
    {
      //Arrange
      string title01 = "Walk the dog";
      string title02 = "Wash the dishes";
      Record newRecord1 = new Record(title01);
      Record newRecord2 = new Record(title02);
      List<Record> newList = new List<Record> { newRecord1, newRecord2 };

      //Act
      List<Record> result = Record.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectRecord_Record()
    {
      //Arrange
      string title01 = "Walk the dog";
      string title02 = "Wash the dishes";
      Record newRecord1 = new Record(title01);
      Record newRecord2 = new Record(title02);

      //Act
      Record result = Record.Find(2);

      //Assert
      Assert.AreEqual(newRecord2, result);
    }

    [TestMethod]
    public void AddArtist_AssociatesArtistWithRecord_ArtistList()
    {
      //Arrange
      string description = "Walk the dog.";
      Artist newArtist = new Artist(description);
      List<Artist> newList = new List<Artist> { newArtist };
      string title = "Walk the dog";
      Record newRecord = new Record(title);
      newRecord.AddArtist(newArtist);

      //Act
      List<Artist> result = newRecord.Artists;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}