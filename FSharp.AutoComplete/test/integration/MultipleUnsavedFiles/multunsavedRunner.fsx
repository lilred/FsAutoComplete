#load "../TestHelpers.fsx"
open TestHelpers
open System.IO
open System

(*
 * This test is a simple sanity check of a basic run of the program.
 * A few completions, files and script.
 *)

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
File.Delete "output.txt"

let p = new FSharpAutoCompleteWrapper()

p.project "multunsaved.fsproj"
p.parse "FileTwo.fs"
p.parse "Program.fs"
p.parseContent "FileTwo.fs" """
module FileTwo

let addTwo2 x y = x + y
"""
p.parse "Program.fs"
p.send "quit\n"
let output = p.finalOutput ()
File.WriteAllText("output.txt", output)
