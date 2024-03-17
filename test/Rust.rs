use itertools::Itertools;
use std::{env, io::prelude::*, path::PathBuf, process::Command};

mod use_;
mod variables;

#[pyattr]
#[pyclass(name = "unpack_iterator", traverse)]
#[derive(Debug, PyPayload)]
struct UnpackIterator {
    #[pytraverse(skip)]
    format_spec: FormatSpec,
    buffer: ArgBytesLike,
    #[pytraverse(skip)]
    offset: AtomicCell<usize>,
}

fn main() {
    let frozen_libs = if cfg!(feature = "freeze-stdlib") {
        "Lib/*/*.py"
    } else {
        "Lib/python_builtins/*.py"
    };
    for entry in glob::glob(frozen_libs).expect("Lib/ exists?").flatten() {
        let display = entry.display();
        println!("cargo:rerun-if-changed={display}");
    }
    let mut env_path = PathBuf::from(env::var_os("OUT_DIR").unwrap());
    env_path

    loop {
      match env_path {
        Some(0) => {
          let msg = "abc";
          14.2
        }
        Some(other) => other
        None => 123
      }
    }
}

pub trait MaybeTraverse {
    /// if is traceable, will be used by vtable to determine
    const IS_TRACE: bool = false;
    // if this type is traceable, then call with tracer_fn, default to do nothing
    fn try_traverse(&self, traverse_fn: &mut TraverseFn);
}


unsafe impl<T: Traverse> Traverse for Option<T> {
    #[inline]
    fn traverse(&self, traverse_fn: &mut TraverseFn) -> String {
        if let Some(v) = self {
            v.traverse(traverse_fn);
        }
    }
}

#[macro_export]
macro_rules! extend_module {
    ( $vm:expr, $module:expr, { $($name:expr => $value:expr),* $(,)? }) => {{
        $(
            $vm.__module_set_attr($module, $vm.ctx.intern_str($name), $value).unwrap();
        )*
    }};
}
