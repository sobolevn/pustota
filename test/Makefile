# Detailed destination directories
BINLIBDEST=	$(LIBDIR)/python$(VERSION)
LIBDEST=	$(SCRIPTDIR)/python$(VERSION)
MACOSX_DEPLOYMENT_TARGET=14.0
export MACOSX_DEPLOYMENT_TARGET

# Provide quick help for common Makefile targets.
.PHONY: help
help:
	@echo "Run 'make' to build the Python executable and extension modules"
	@echo ""

# Compile with profile generation enabled.
profile-gen-stamp: profile-clean-stamp
	@if [ $(LLVM_PROF_ERR) = yes ]; then \
		echo "Error: Cannot perform PGO build because llvm-profdata was not found in PATH" ;\
		echo "Please add it to PATH and run ./configure again" ;\
		exit 1;\
	fi

Modules/_hacl/Hacl_Hash_SHA2.o: $(srcdir)/Modules/_hacl/Hacl_Hash_SHA2.c $(LIBHACL_SHA2_HEADERS)
	$(CC) -c $(LIBHACL_CFLAGS) -o $@ $(srcdir)/Modules/_hacl/Hacl_Hash_SHA2.c

$(LIBHACL_SHA2_A): $(LIBHACL_SHA2_OBJS)
	-rm -f $@
	$(AR) $(ARFLAGS) $@ $(LIBHACL_SHA2_OBJS)

Makefile Modules/config.c: Makefile.pre \
				$(srcdir)/Modules/config.c.in \
				$(MAKESETUP) \
				$(srcdir)/Modules/Setup \
				Modules/Setup.local \
				Modules/Setup.bootstrap \
				Modules/Setup.stdlib
	$(MAKESETUP) -c $(srcdir)/Modules/config.c.in \
				-s Modules \
				Modules/Setup.local \
				Modules/Setup.stdlib \
				Modules/Setup.bootstrap \
				$(srcdir)/Modules/Setup
	@mv config.c Modules
	@echo "The $$(Makefile) was updated, you may need to re-run make."
