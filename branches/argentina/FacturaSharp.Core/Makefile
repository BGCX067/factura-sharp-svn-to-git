SUB_DIRS=sslw \
Pkcs7

#all: _all _post
all: _all

clean: _clean

_all:
	@for dn in $(SUB_DIRS) ; do \
		$(MAKE) -C $$dn output_prefix=$(output_prefix) project_libs_dir=$(project_libs_dir) all;\
	done

_clean:
	@for dn in $(SUB_DIRS) ; do \
		$(MAKE) -C $$dn output_prefix=$(output_prefix) project_libs_dir=$(project_libs_dir) clean; \
	done

