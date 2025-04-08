#!/bin/bash

set -e

PROJECT_DIR="../src/Archy.CLI" 

usage() {
  echo "Usage: ./scripts/archy-run [--dev] [-- <dotnet_run_args>]"
  echo ""
  echo "Options:"
  echo "     --dev    Sets ASPNETCORE_ENVIRONMENT=Development before running."
  echo "     --       Passes all subsequent arguments directly to 'dotnet run'."
  echo ""
  echo "Example:"
  echo "  ./scripts/archy-run --dev"
  exit 1
}

is_dev=false
passthrough_args=()

while [[ $# -gt 0 ]]; do
  key="$1"
  case $key in
    --dev)
      is_dev=true
      shift 
      ;;
    --) 
      shift 
      passthrough_args+=("$@") 
      break 
      ;;
    -h|--help)
      usage
      ;;
    -*)
      echo "Error: Unknown option '$key'" >&2
      usage
      ;;
     *)
      echo "Error: Unexpected argument '$key'" >&2
      usage
      ;;
  esac
done


cd "$PROJECT_DIR" 

cmd_array=("dotnet" "run")


if [ ${#passthrough_args[@]} -gt 0 ]; then
   cmd_array+=("${passthrough_args[@]}")
fi


echo "--------------------------------------------------"
if [ "$is_dev" = true ]; then
  echo "Starting DEVELOPMENT run (DOTNET_ENVIRONMENT=Development)..."
  echo "Command: DOTNET_ENVIRONMENT=Development ${cmd_array[*]}"
  echo "--------------------------------------------------"

  DOTNET_ENVIRONMENT=Development "${cmd_array[@]}"
else
  echo "Starting PRODUCTION/DEFAULT run..."
  echo "Command: ${cmd_array[*]}"
  echo "--------------------------------------------------"
  # Opt set or unset the environment for production
  # unset DOTNET_ENVIRONMENT
  # export DOTNET_ENVIRONMENT=Production
  "${cmd_array[@]}"
fi
echo "--------------------------------------------------"
echo "Run finished."

cd - > /dev/null

exit 0