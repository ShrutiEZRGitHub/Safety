#!/bin/bash -e

echo "Gonna try build for the Commit ID - " ${CODEBUILD_RESOLVED_SOURCE_VERSION}

git --version

parentId=`aws codecommit batch-get-commits --repository-name AG_CC_BUDGET_CD --commit-ids ${CODEBUILD_RESOLVED_SOURCE_VERSION} | jq -r '.commits[0].parents[0]'`

echo "ParentId (Previous Commit ID):" $parentId

diffJson=`aws codecommit get-differences --repository-name AG_CC_BUDGET_CD --before-commit-specifier $parentId --after-commit-specifier ${CODEBUILD_RESOLVED_SOURCE_VERSION}`

echo "DIFFS -" $diffJson

diffSize=`echo $diffJson | jq '.differences | length'`

echo $diffSize " file(s) changed in the Commit ID - " ${CODEBUILD_RESOLVED_SOURCE_VERSION}

for microservice in $(echo $diffJson | jq -r '.differences[] | .afterBlob.path' | cut -d/ -f1)
do
    if [[ "$microservice" ==  'API' || "$microservice" == 'DB' ]]; then
        echo "Changes detected in - " $microservice ". Triggering build for " $microservice
        aws codepipeline start-pipeline-execution --name AG_CPL_BudgetAPI_CD
        APIflag="true"
        break
    fi
done

for microservice in $(echo $diffJson | jq -r '.differences[] | .afterBlob.path' | cut -d/ -f1)
do
    if [[ "$microservice" == 'WasmUI' ]]; then
        echo "Changes detected in - " $microservice ". Triggering build for " $microservice
        aws codepipeline start-pipeline-execution --name ED_CPL_BudgetWeb_CD
        WEBflag="true"
        break
    fi
done

for microservice in $(echo $diffJson | jq -r '.differences[] | .afterBlob.path' | cut -d/ -f1)
do
    if [[ "$microservice" !=  'API' && "$microservice" != 'WasmUI' && "$microservice" != 'DB' ]]; then
        if [ "$APIflag" != "true" ]; then
            echo "Executing API Pipeline."
            aws codepipeline start-pipeline-execution --name AG_CPL_BudgetAPI_CD
        fi
        if [ "$WEBflag" != "true" ]; then
            echo "Executing WEB Pipeline."
            aws codepipeline start-pipeline-execution --name ED_CPL_BudgetWeb_CD
        fi
        break
    fi
done