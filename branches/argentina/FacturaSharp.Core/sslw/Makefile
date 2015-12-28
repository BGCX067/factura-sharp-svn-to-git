SUB_DIRS=src \
	tests

all: _all

clean: _clean

_all:
	@echo "compilando ssl wrapper"
	@for dn in $(SUB_DIRS) ; do \
		$(MAKE) -C $$dn output_prefix=$(output_prefix) project_libs_dir=$(project_libs_dir) all; \
	done
	[ ! -e lib ] && ln -s build/linux ./lib 2> /dev/null || test 0
_clean:
	@for dn in $(SUB_DIRS) ; do \
		$(MAKE) -C $$dn output_prefix=$(output_prefix) project_libs_dir=$(project_libs_dir) clean; \
	done
	rm lib 2> /dev/null || test 0
