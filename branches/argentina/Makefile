SUB_DIRS=FacturaSharp.Core argentina 

output_prefix=$(PWD)/lib
project_libs_dir=$(PWD)/lib

all: _first _all _post

clean: _clean

_first: 
	mkdir lib || test 0
_all:
	[ ! -e lib ] && mkdir lib 2> /dev/null || test 0
	@for dn in $(SUB_DIRS) ; do \
		$(MAKE) -C $$dn output_prefix=$(output_prefix) project_libs_dir=$(project_libs_dir) all;\
	done
_post:
	@for dn in $(SUB_DIRS) ; do \
		cp -f $$dn/lib/* lib 2> /dev/null || test 0; \
	done
_clean:
	@for dn in $(SUB_DIRS) ; do \
		$(MAKE) -C $$dn output_prefix=$(output_prefix) project_libs_dir=$(project_libs_dir) clean; \
	done
	#rm lib/* 2>/dev/null || test 0
