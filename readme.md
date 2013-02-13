
mono-project
============

I'm giving up on this project because of the state of mono. I don't want to invest too much time into this,
but to me, mono is unusable. The Linux (Ubuntu) packages are outdated, the source is not easy to compile,
documentation is not very good and the implementation is still far behind the current .NET version. I know
it's open source and I should not complain but do something about it... Anyway, "messenger" needs to be
implemented and it must run on Linux, so I'm switching to play! framework on JVM with this project before
investing the time into learning NancyFX only to discover it won't run on mono.
https://github.com/mattanja/messenger

messenger
=========

messenger is intended to be a lightweight replacement for good old GNU mailman.
(At the moment it is only a test project for NancyFX and Service Stack hosted on Linux/Mono.)

The following issues will be addressed:
* Simple setup, simple configuration and independent from the underlying mailing system
* Receiving mail from members of a list will forward mail to all members of the list
* Web API for list management and sending mail

Out of scope (for the time being):
* Mail archive
* Spam filtering (list of accepted remote servers though, so spam filtering can be done on regular mail server)
