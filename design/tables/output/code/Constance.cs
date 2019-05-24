// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: Constance.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Com.Gear.Packer {

  /// <summary>Holder for reflection information generated from Constance.proto</summary>
  public static partial class ConstanceReflection {

    #region Descriptor
    /// <summary>File descriptor for Constance.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConstanceReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9Db25zdGFuY2UucHJvdG8SD2NvbS5nZWFyLnBhY2tlchoPRGF0YUxldmVs",
            "LnByb3RvIjoKCUNvbnN0YW5jZRItCglsZXZlbExpc3QYASADKAsyGi5jb20u",
            "Z2Vhci5wYWNrZXIuRGF0YUxldmVsYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Com.Gear.Packer.DataLevelReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Com.Gear.Packer.Constance), global::Com.Gear.Packer.Constance.Parser, new[]{ "LevelList" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Constance : pb::IMessage<Constance> {
    private static readonly pb::MessageParser<Constance> _parser = new pb::MessageParser<Constance>(() => new Constance());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Constance> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Com.Gear.Packer.ConstanceReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Constance() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Constance(Constance other) : this() {
      levelList_ = other.levelList_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Constance Clone() {
      return new Constance(this);
    }

    /// <summary>Field number for the "levelList" field.</summary>
    public const int LevelListFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Com.Gear.Packer.DataLevel> _repeated_levelList_codec
        = pb::FieldCodec.ForMessage(10, global::Com.Gear.Packer.DataLevel.Parser);
    private readonly pbc::RepeatedField<global::Com.Gear.Packer.DataLevel> levelList_ = new pbc::RepeatedField<global::Com.Gear.Packer.DataLevel>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Com.Gear.Packer.DataLevel> LevelList {
      get { return levelList_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Constance);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Constance other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!levelList_.Equals(other.levelList_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= levelList_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      levelList_.WriteTo(output, _repeated_levelList_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += levelList_.CalculateSize(_repeated_levelList_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Constance other) {
      if (other == null) {
        return;
      }
      levelList_.Add(other.levelList_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            levelList_.AddEntriesFrom(input, _repeated_levelList_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
