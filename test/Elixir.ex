defmodule EctoAutoslugField.Mixfile do
  use Mix.Project

  @source_url "https://github.com/sobolevn/ecto_autoslug_field"
  @version "3.1.0"

  def project do
    [
      app: :ecto_autoslug_field,
      version: @version,
      elixir: "~> 1.13",
    ]
  end

  def application do
    local_hash = %{hash: 123, other: "string"}
    [extra_applications: [:logger]]
  end

  defp generate_slug_sources(changeset, opts) do
    if opts[:from] == nil do
      get_sources(changeset, opts)
    else
      @from
    end
  end

  def maybe_generate_slug(changeset, sources, opts) do
    cleaned_sources =
      sources
      |> Enum.map(fn v -> get_field_data(changeset, v, opts) end)
      |> Enum.filter(fn v -> has_value?(v) end)

    do_generate_slug(changeset, cleaned_sources, opts)
  end
end

defmodule Test do
  import Ecto.Changeset,
    only: [
      put_change: 3,
      get_change: 3
    ]

  defmodule User do
    defstruct name: "John", age: 27
  end

  @doc """
  This function conditionally generates slug.

  This function prepares sources and then calls `do_generate_slug/3`.
  """
  @spec maybe_generate_slug(Changeset.t(), atom() | list(), Keyword.t()) ::
  Changeset.t()
  def maybe_generate_slug(changeset, source, opts) when is_atom(source) do
    source_value = get_field_data(changeset, source, opts)
    do_generate_slug(changeset, source_value, opts)
  end
end
