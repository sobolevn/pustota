# Changelog

All notable changes to the "pustota" extension will be documented in this file.

Check [Keep a Changelog](http://keepachangelog.com/) for recommendations on how to structure this file.

## 0.0.16

- Fixes installation problem

## 0.0.15

- Fixes how functions deinitions with names
  like `__module__` or `set` are highlighted in Python

## 0.0.14

- Improve `C` highlight: do not colorize builtin types
- Imporve `go` highlight: highlight function names

## 0.0.13

- Revert `0.0.12` change

## 0.0.12

- Fixes Python builtins not highlighted when used as function names

## 0.0.11

- Fixes old legacy Python builtins not highlighted when used as function names

## 0.0.10

- Fixes `${}` highlight in JS / TS
- Fixes last char highlight when typing a string without ending quote in JS / TS

## 0.0.9

- Fixes `alias` keyword in Bash

## 0.0.8

- Added Lisp support

## 0.0.7

- Fixed `mod` highlight in Rust
- Fixed `->` in Python annotations highlight

## 0.0.6

- Fixed Markdown headings highlight
- Fixed keywords highligh in jsdoc, phpdoc, etc
- Fixed Makefile syntax highlights
- Fixed PHP syntax highlights
- Added configuration instructions
- Ignored multiple folders from the result build

## 0.0.5

- Fixed ternary operator in Ruby
- Fixed `.editorconfig` file colors
- Fixed INI and TOML colors
- Fixed escape chars in Python's strings
- Fixed Bash's function definitions

## 0.0.4

- Fix several Markdown syntax highlights
- Fixed theme name to be lowercase: `pustota`

## 0.0.3

- Fixes multiple JS and TS syntax highlights
- Removes "incorrect" scope matcher
- Enforce more `#0A0E14` usage

## 0.0.2

- Adds theme icon

## 0.0.1

- Initial release
