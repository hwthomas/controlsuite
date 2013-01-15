ControlSuite
============

A suite of tools for the configuration, implementation and tuning of
classical control systems.


Introduction
============

ControlSuite brings together a number of tools, written in C#, for 
configuring and implementing practical process control systems, and
for tuning and optimising their performance.

These are as follows:

	* CSPlot:  an interactive chart/plotting library
	* CSTools: a function block configuration editor/simulator
	* CSTune:  an open-loop time/frequency domain tuner

All tools are written in C#, and use the Xwt cross-platform UI toolkit
so that they may be run on linux, Mac and Windows systems.


CSPlot
======

This plotting package provides facilities for displaying time and
frequency domain plots in a number of formats.


CSTools
=======

Uses Function Blocks to configure and simulate control systems and
the physical processes being controlled.


CSTune
======

Provides analysis and design tools for optimising control systems based
on open-loop step tests of the process. Fourier transforms of these tests
enable classical frequency domain approaches to be used for tuning the
most common types of process controller.


